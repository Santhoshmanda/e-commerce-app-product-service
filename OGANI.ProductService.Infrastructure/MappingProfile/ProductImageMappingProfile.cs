﻿using System;
using AutoMapper;
using OGANI.ProductService.Infrastructure.Entities;
using Models=OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Infrastructure.MappingProfile
{
	public class ProductImageMappingProfile :Profile
	{
		public ProductImageMappingProfile()
		{
            CreateMap<Models.ProductImage, ProductImage>();
            CreateMap<ProductImage, Models.ProductImage>();
        }
	}
}

