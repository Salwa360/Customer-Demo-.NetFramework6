using AutoMapper;

namespace BasicData.Infrastructure.Mapper
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
