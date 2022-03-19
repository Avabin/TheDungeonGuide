using AutoMapper;

namespace Mongo;

public class DataMapperProfile<TCreate, TGet, TUpdate, TDoc> : Profile
{
    public DataMapperProfile()
    {
        CreateMap<TDoc, TCreate>().ReverseMap();
        CreateMap<TDoc, TGet>().ReverseMap();
        CreateMap<TDoc, TUpdate>().ReverseMap();
        CreateMap<TCreate, TGet>().ReverseMap();
        CreateMap<TUpdate, TGet>().ReverseMap();
        CreateMap<TCreate, TUpdate>().ReverseMap();
    }
}