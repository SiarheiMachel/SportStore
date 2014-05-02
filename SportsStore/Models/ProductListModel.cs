using System.Collections.Generic;
using SportsStore.DataAccess;

namespace SportsStore.Web.Models
{
    public class ProductListModel
    {
        public List<Product> Products { get; set; } 
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}