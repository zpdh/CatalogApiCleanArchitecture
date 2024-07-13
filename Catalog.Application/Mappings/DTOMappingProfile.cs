﻿using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings;

public class DTOMappingProfile : Profile
{
    public DTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    } 
}