using System;
using AutoMapper;
using OGANI.ProductService.Infrastructure.Entities;
using Models=OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Infrastructure.MappingProfile
{
	public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<Models.Product, Product>();
            CreateMap<Product, Models.Product>();
        }
	}
}

