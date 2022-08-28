using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDTO, Supplier>();
            this.CreateMap<PartDTO, Part>();
            this.CreateMap<CarDTO, Car>();
            this.CreateMap<PartCarsDTO, PartCar>();
            this.CreateMap<CustomerDTO, Customer>();
            this.CreateMap<SaleDTO, Sale>();
            this.CreateMap<Customer, CustomerDTO>();
            this.CreateMap<Car, CarDTO>();
            this.CreateMap<Supplier, ExportLocalSupppliersDTO>();
        }
    }
}
