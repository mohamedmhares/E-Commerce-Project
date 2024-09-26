using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Core.Specifications
{
    public class ProductSpecParams
    {
        public const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _PageSize { get; set; } = 6;

        public int PageSize 
        {
            get => _PageSize;
            //if page size > Max PageSize(50) let _pageSize = MaxPage Size
            set => _PageSize = (value > MaxPageSize) ? PageSize : value;
        }
        public int? brnadId { get; set; }
        public int? typeId { get; set; }
        public string sort { get; set; }
        private string _search { get; set; }
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }

    }
}
