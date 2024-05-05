using System;
using AutoMapper;
using OGANI.ProductService.Infrastructure.Entities;
using Models=OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Infrastructure.MappingProfile
{
	public class CategoryMappingProfile : Profile
    {
		public CategoryMappingProfile()
		{
			CreateMap<Models.Category, Category>();
            CreateMap<Category, Models.Category>();

        }
	}
}

