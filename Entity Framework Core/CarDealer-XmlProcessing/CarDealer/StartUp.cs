using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupllierDTO[]), xmlRootAttribute);
            StringReader sw = new StringReader(inputXml);
            SupllierDTO[] suplliers = (SupllierDTO[])xmlSerializer.Deserialize(sw);

            List<Supplier> toAdd = new List<Supplier>();
            foreach (var item in suplliers)
            {
                toAdd.Add(new Supplier() { Name = item.Name, IsImporter = item.IsImporter });
            }
            context.Suppliers.AddRange(toAdd);
            context.SaveChanges();
            return $"Successfully imported {toAdd.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            int[] supIds = context.Suppliers.Select(x => x.Id).ToArray();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartsDTO[]), xmlRoot);
            StringReader sr = new StringReader(inputXml);
            PartsDTO[] partsDTOs = (PartsDTO[])xmlSerializer.Deserialize(sr);
            List<Part> parts = new List<Part>();
            foreach (var item in partsDTOs)
            {
                if (!supIds.Contains(item.SupplierId))
                {
                    continue;
                }
                parts.Add(new Part() { Name = item.Name, Price = item.Price, SupplierId = item.SupplierId, Quantity = item.Quantity });
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {


            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsDTO[]), xmlRoot);
            StringReader sr = new StringReader(inputXml);
            CarsDTO[] carsDTOs = (CarsDTO[])xmlSerializer.Deserialize(sr);
            List<Car> cars = new List<Car>();

            foreach (var item in carsDTOs)
            {
                Car car = new Car() { Make = item.Make, Model = item.Model, TravelledDistance = item.TravelledDistance };

                List<PartCar> currentPartsCar = new List<PartCar>();
                foreach (int part in item.PartsIds.Select(x => x.Id).Distinct())
                {
                    if (!context.Parts.Any(x => x.Id == part))
                    {
                        continue;
                    }
                    PartCar partCar = new PartCar() { PartId = part, CarId = car.Id };
                    currentPartsCar.Add(partCar);
                }

                car.PartCars = currentPartsCar;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerDTO[]), xmlRootAttribute);

            StringReader stringReader = new StringReader(inputXml);
            CustomerDTO[] customersDTOs = (CustomerDTO[])xmlSerializer.Deserialize(stringReader);

            List<Customer> customers = new List<Customer>();
            foreach (var item in customersDTOs)
            {
                customers.Add(new Customer() { Name = item.Name, BirthDate = item.BirthDate, IsYoungDriver = item.IsYoungDriver });
            }


            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleDTO[]), xmlRootAttribute);
            StringReader stringReader = new StringReader(inputXml);
            SaleDTO[] salesDTOs = (SaleDTO[])xmlSerializer.Deserialize(stringReader);

            int[] carIds = context.Cars.Select(x => x.Id).ToArray();

            List<Sale> sales = new List<Sale>();
            foreach (var item in salesDTOs)
            {
                if (carIds.Contains(item.CarId))
                {
                    sales.Add(new Sale() { CarId = item.CarId, CustomerId = item.CustomerId, Discount = item.Discount });
                }

            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarDTOExport[] cars = context.Cars
                                         .OrderBy(x => x.Make)
                                         .ThenBy(x => x.Model)
                                         .Take(10)
                                         .Select(x => new CarDTOExport()
                                         {
                                             Make = x.Make,
                                             Model = x.Model,
                                             TravelledDistance = x.TravelledDistance
                                         }).ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarDTOExport[]), xmlRootAttribute);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, cars, xmlSerializerNamespaces);
            return sw.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            BmwCarDTO[] cars = context.Cars
                                         .OrderBy(x => x.Model)
                                         .ThenByDescending(x => x.TravelledDistance)
                                         .Where(x => x.Make == "BMW")
                                         .Select(x => new BmwCarDTO()
                                         {
                                             Id = x.Id,
                                             Model = x.Model,
                                             TravelledDistance = x.TravelledDistance
                                         }).ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BmwCarDTO[]), xmlRootAttribute);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, cars, xmlSerializerNamespaces);
            return sw.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            SuplierDTO[] suplierDTOs = context.Suppliers
                                              .Where(x => x.IsImporter == false)
                                              .Select(x => new SuplierDTO() { Id = x.Id, Name = x.Name, partsCount = x.Parts.Count }).ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SuplierDTO[]), xmlRootAttribute);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, suplierDTOs, xmlSerializerNamespaces);


            return sw.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CarWithPartsDTO[] carWithParts = context.Cars
                                                   .OrderByDescending(x => x.TravelledDistance)
                                                   .ThenBy(x => x.Model)
                                                   .Take(5)
                                                   .Select(x => new CarWithPartsDTO()
                                                   {
                                                       Make = x.Make,
                                                       Model = x.Model,
                                                       TravelledDistance = x.TravelledDistance,
                                                       Parts = x.PartCars.OrderByDescending(p => p.Part.Price).Select(p => new PartDTO() { Price = p.Part.Price, Name = p.Part.Name }).ToList()
                                                   })
                                                   .ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarWithPartsDTO[]), xmlRootAttribute);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, carWithParts, xmlSerializerNamespaces);


            return sw.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            CustomerDTOExport[] customers = context.Customers
                                                   .Where(x => x.Sales.Count > 0)
                                                   .ToArray()
                                                   .Select(x => new CustomerDTOExport()
                                                   {
                                                       FullName = x.Name,
                                                       BoughtCars = x.Sales.Count,
                                                       SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                                                   })
                                                   .OrderByDescending(x => x.SpentMoney)
                                                   .ToArray();



            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerDTOExport[]), xmlRootAttribute);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, customers, xmlSerializerNamespaces);


            return sw.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            SaleExportDTO[] sales = context.Sales
                                           .Select(x => new SaleExportDTO()
                                           {
                                               Price = x.Car.PartCars.Sum(p => p.Part.Price),
                                               CustomerName = x.Customer.Name,
                                               Discount = x.Discount,
                                               PriceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) * (1 - (x.Discount / 100))),
                                               Car = new SaleCarDTO() { Make = x.Car.Make, Model = x.Car.Model, TravelledDistance = x.Car.TravelledDistance }
                                           })
                                           .ToArray();


            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleExportDTO[]), xmlRootAttribute);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, sales, xmlSerializerNamespaces);


            return sw.ToString().TrimEnd();
        }
    }
}