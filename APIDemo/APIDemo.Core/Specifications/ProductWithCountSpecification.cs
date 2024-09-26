using APIDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Core.Specifications
{
    public class ProductWithCountSpecification : BaseSpecification<Product>
    {
        public ProductWithCountSpecification(ProductSpecParams productParams)
            : base(x =>
            //here is If product params.brandId hs value let the x.brandID here in ctor equal the givin value 
            (!productParams.brnadId.HasValue || x.ProductBrandId == productParams.brnadId) &&
            (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
                  )
        {
            
        }
    }
}
