using AutoMapper;
using CodeFirst.Core.DTOs.Product.Requests;
using CodeFirst.Core.DTOs.Product.Responses;
using CodeFirst.Domain.Entities;
using System.Text;

namespace CodeFirst.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            CreateMap<ProductAddDtoRequest, Product>()
                .ForMember(x => x.Images, options => options.MapFrom(src => MapImages(src.Images)))
                ;
            CreateMap<Product, ProductDtoResponse>()
                .ForMember(x => x.Images, options => options.MapFrom(src => src.Images == null ? "" : Encoding.UTF8.GetString(src.Images)));
        }

        private static byte[] MapImages(string imagen)
        {
            var contenido = Encoding.ASCII.GetBytes(imagen);
            return contenido;
        }
    }
}