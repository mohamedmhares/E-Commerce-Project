using APIDemo.Core.Entities;
using APIDemo.Core.Interfaces;
using APIDemo.Core.Specifications;
using APIDemo.Dtos;
using APIDemo.Helpers;
using APIDemo.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController 
    {
        private readonly StoreContext _context;
        private readonly IProductRebository _productRebository;
        private readonly IGenericRebository<Product> _productRepo;
        private readonly IGenericRebository<ProductBrand> _productBrandRepo;
        private readonly IGenericRebository<ProductType> _productTyprRepo;
        private readonly IMapper _mapper;



        public ProductController(IGenericRebository<Product> productRepo, IGenericRebository<ProductBrand> productBrandRepo, IGenericRebository<ProductType> productTyprRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTyprRepo = productTyprRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(productSpecParams) ;
            var countspec = new ProductWithCountSpecification(productSpecParams) ;
            var totalItems = await _productRepo.CountAsync(countspec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
            return Ok(new Pagination<ProductDTO>(productSpecParams.PageIndex, productSpecParams.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDTO>(product);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productBrandRepo.GetByAllAsync());
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductType>>> GetProductBrands()
        {
            return Ok(await _productTyprRepo.GetByAllAsync());
        }
    }
}
