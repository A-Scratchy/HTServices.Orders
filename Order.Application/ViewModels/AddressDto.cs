using System;
using AutoMapper;
using Orders.Application.Interfaces;
using Orders.Domain.OrderAggregate;

namespace Orders.Application.ViewModels
{
    public class AddressDto : IMapFrom<Address>
    {
        public Guid AddressId { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostCode { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDto>();
        }
    }
}