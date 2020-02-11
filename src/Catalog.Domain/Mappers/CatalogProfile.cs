using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;
using Catalog.Domain.Requests.Item;

namespace Catalog.Domain.Mappers
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<ItemResponse, Item>().ReverseMap();
            CreateMap<GenreResponse, Genre>().ReverseMap();
            CreateMap<ArtistResponse, Artist>().ReverseMap();
            CreateMap<Price, PriceResponse>().ReverseMap();
            CreateMap<AddItemRequest, Item>().ReverseMap();
            CreateMap<EditItemRequest, Item>().ReverseMap();
        }
    }
}
