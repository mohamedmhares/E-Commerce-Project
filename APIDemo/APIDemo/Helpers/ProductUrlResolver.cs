using APIDemo.Core.Entities;
using APIDemo.Dtos;
using AutoMapper;

namespace APIDemo.Helpers
{
    //We Use This Class to Map Image URl
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _configuration["ApiUrl"] + source.ImageUrl;
            }
            return null;
        }
    }
}
