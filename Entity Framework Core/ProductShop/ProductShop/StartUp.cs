using ProductShop.Data;

namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {


        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //  string s=GetProductsInRange(context);

            Console.WriteLine(GetUsersWithProducts(context));

            //Console.WriteLine(ImportProducts(context, File.ReadAllText("../../../Datasets/products.xml"))); 
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersDTO[]), xmlRootAttribute);
            using StringReader stringReader = new StringReader(inputXml);
            UsersDTO[] usersDTOs = (UsersDTO[])xmlSerializer.Deserialize(stringReader);
            User[] users = usersDTOs.Select(x => new User() { FirstName = x.FirstName, LastName = x.LastName, Age = x.Age }).ToArray();
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductDTO[]), xmlRootAttribute);
            using StringReader sr = new StringReader(inputXml);
            ProductDTO[] products = (ProductDTO[])xmlSerializer.Deserialize(sr);
            int[] IDS = context.Users.Select(x => x.Id).ToArray();

            List<Product> toAdd = new List<Product>();
            foreach (var x in products)
            {
                Product products1 = new Product() { Name = x.Name, Price = x.Price, SellerId = x.SellerId, BuyerId = x.BuyerId };
                toAdd.Add(products1);



            }

            foreach (var item in toAdd)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();
            return $"Successfully imported {toAdd.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryDTO[]), xmlRootAttribute);
            using StringReader stringReader = new StringReader(inputXml);

            CategoryDTO[] categoriesDTOs = (CategoryDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Category> categories = new List<Category>();
            foreach (var item in categoriesDTOs)
            {
                if (item.Name == null)
                {
                    continue;
                }
                categories.Add(new Category() { Name = item.Name });
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductDTO[]), xmlRootAttribute);
            using StringReader stringReader = new StringReader(inputXml);

            CategoryProductDTO[] dtos = (CategoryProductDTO[])xmlSerializer.Deserialize(stringReader);

            int[] categoriesIds = context.Categories.Select(x => x.Id).ToArray();
            int[] productsIds = context.Products.Select(x => x.Id).ToArray();

            ICollection<CategoryProduct> toAdd = new List<CategoryProduct>();
            foreach (var item in dtos)
            {
                if (categoriesIds.Contains(item.CategoryId) && productsIds.Contains(item.ProductId))
                {
                    toAdd.Add(new CategoryProduct() { ProductId = item.ProductId, CategoryId = item.CategoryId });
                }
            }
            context.CategoryProducts.AddRange(toAdd);
            context.SaveChanges();
            return $"Successfully imported {toAdd.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            //StringBuilder sb = new StringBuilder();
            //ExProductDTO[] products = context.Products
            //                      .Where(x => x.Price >= 500 && x.Price <= 1000)
            //                      .OrderBy(x => x.Price)
            //                      .Take(10)
            //                      .Select(x => new ExProductDTO()
            //                      {
            //                          Name = x.Name,
            //                          Price = x.Price.ToString(),
            //                          BuyerFullName = x.Buyer.FirstName + " " + x.Buyer.LastName
            //                      }
            //                             )
            //                      .ToArray();
            //XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            //xmlns.Add(string.Empty, string.Empty);
            //XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Products");
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExProductDTO[]), xmlRootAttribute);
            //StringWriter sw = new StringWriter(sb);
            //xmlSerializer.Serialize(sw, products, xmlns);
            //return sb.ToString().TrimEnd();
            return "";
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserDTO[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            UserDTO[] userWithSoldProductsDtos = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ExProductDTO()
                    {
                        Name = ps.Name,
                        Price = ps.Price.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, userWithSoldProductsDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersWithProductsDTO), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            var userWithSoldProductsDtos = new UsersWithProductsDTO()
            {
                count = context.Users.Where(x => x.ProductsSold.Count > 0).Count(),
                users = context.Users.Where(u => u.ProductsSold.Count > 0)
                 .OrderByDescending(u => u.ProductsSold.Count)
                 .Take(10).Select(us => new UserProdDTO()
                 {
                     FirstName = us.FirstName,
                     LastName = us.LastName,
                     Age = us.Age,
                     SoldProducts = new SoldProductsDTO()
                     {
                         count = us.ProductsSold.Count,
                         SoldProducts = new ProdBefDTO()
                         {
                             prodss = us.ProductsSold.Select(p => new ExProductDTO()
                             {
                                 Name = p.Name,
                                 Price = p.Price.ToString()
                             }).ToArray()

                         }
                     }
                 }).ToArray()
            };

            xmlSerializer.Serialize(stringWriter, userWithSoldProductsDtos, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static void InitializeMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }
    }
}