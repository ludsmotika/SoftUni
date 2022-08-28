using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            Mapper.Initialize(cfg => { cfg.AddProfile<CarDealerProfile>(); });

            string jsonText = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(jsonText);

            File.WriteAllText("../../../Datasets", "sales-discounts.json");

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            SupplierDTO[] suppliersDTO = JsonConvert.DeserializeObject<SupplierDTO[]>(inputJson);

            ICollection<Supplier> sups = new List<Supplier>();
            foreach (SupplierDTO item in suppliersDTO)
            {
                Supplier supplier = Mapper.Map<Supplier>(item);
                sups.Add(supplier);
            }

            context.Suppliers.AddRange(sups);
            context.SaveChanges();
            return $"Successfully imported {sups.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {

            PartDTO[] partsDTO = JsonConvert.DeserializeObject<PartDTO[]>(inputJson);

            ICollection<Part> parts = new List<Part>();

            int[] ids = context.Suppliers.Select(x => x.Id).ToArray();

            foreach (PartDTO item in partsDTO)
            {
                Part part = Mapper.Map<Part>(item);
                if (ids.Contains(part.SupplierId))
                {
                    parts.Add(part);
                }

            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            CarDTO[] cars = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);


            foreach (CarDTO item in cars)
            {

                Car current = Mapper.Map<Car>(item);
                context.Cars.Add(current);


                //foreach (var id in item.PartsId)
                //{
                //    PartCar partcar = new PartCar() { CarId = current.Id, PartId = id };


                //    if (current.PartCars.FirstOrDefault(x => x.PartId == id) == null)
                //    {
                //        context.PartCars.Add(partcar);
                //    }
                //}
            }



            context.SaveChanges();
            return $"Successfully imported {cars.Length}.";




        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            CustomerDTO[] Customers = JsonConvert.DeserializeObject<CustomerDTO[]>(inputJson);

            ICollection<Customer> toAdd = new List<Customer>();

            foreach (var item in Customers)
            {
                Customer customer = Mapper.Map<Customer>(item);
                toAdd.Add(customer);
            }

            context.Customers.AddRange(toAdd);
            context.SaveChanges();
            return $"Successfully imported {Customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            SaleDTO[] sales = JsonConvert.DeserializeObject<SaleDTO[]>(inputJson);

            ICollection<Sale> toAdd = new List<Sale>();

            foreach (var item in sales)
            {
                Sale current = Mapper.Map<Sale>(item);
                toAdd.Add(current);
            }

            context.Sales.AddRange(toAdd);
            context.SaveChanges();
            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new { Name = x.Name, BirthDate = x.BirthDate.ToString("dd/MM/yyyy"), IsYoungDriver = x.IsYoungDriver })
                .ToArray();
            //.OrderBy(x => x.BirthDate).ThenBy(x=>x.IsYoungDriver).ProjectTo<CustomerDTO>().ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            ExportCarDTO[] cars = context.Cars
                                         .Where(x => x.Make == "Toyota")
                                         .OrderBy(x => x.Model)
                                         .ThenByDescending(x => x.TravelledDistance)
                                         .ProjectTo<ExportCarDTO>()
                                         .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSupppliersDTO[] suppliers = context.Suppliers
                                            .Where(x => x.IsImporter == false)
                                            .ProjectTo<ExportLocalSupppliersDTO>()
                                            .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })

                });

            string carsWithPartsAsJson = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);

            return carsWithPartsAsJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context) 
        {
            var anonymous = context.Customers.Where(x=>x.Sales.Count>0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(g=>g.Car.PartCars.Sum(j=>j.Part.Price))
                }).OrderByDescending(x=>x.spentMoney).ThenByDescending(x=>x.boughtCars).ToArray();

            string answer= JsonConvert.SerializeObject(anonymous);
            return answer;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context) 
        {
            var result = context
                  .Sales
                  .Select
                  (
                          x => new
                          {
                              car = new 
                                        { 
                                                 Make = x.Car.Make,
                                                 Model = x.Car.Model,
                                                 TravelledDistance = x.Car.TravelledDistance 
                                        },
                              customerName = x.Customer.Name,
                              Discount = x.Discount.ToString("f2"),
                              price = x.Car.PartCars.Sum(j => j.Part.Price).ToString("f2"),
                              priceWithDiscount = (x.Car.PartCars.Sum(j => j.Part.Price)  * (1-(x.Discount/100))).ToString("f2")
                          }
                  ).Take(10).ToArray();

            string answer = JsonConvert.SerializeObject(result);
            return answer;
        }
    }
}