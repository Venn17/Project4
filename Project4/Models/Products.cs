using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblProducts")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int SalePrice { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Sold { get; set; }
        public int RestaurantID { get; set; }
        public Restaurants Restaurants { get; set; }
        public int CategoryID { get; set; }
        public Categories Categories { get; set; }
    }
}
