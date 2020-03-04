using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.Models;
using CarDealer.DTO;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<CarDto, Car>();
            CreateMap<Customer, CustomerDto>().ForMember(x => x.BirthDate, y => y.MapFrom(x => x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
