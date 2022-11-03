using AutoMapper;
using Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Products, ProductDTO>();
            CreateMap<Users, UserDTO>();
            CreateMap<Orders, OrderDTO>();
            CreateMap<Categories, CategoryDTO>();

        }
    }
}
