﻿namespace ShopEasy.Api.Customers.Profile
{
    public class CustomerProfile :AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<Db.Customer, Models.Customer>();
        }
    }
}
