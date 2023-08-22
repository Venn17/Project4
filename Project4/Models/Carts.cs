using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblCarts")]
    public class Carts
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Products Products { get; set; }
        public int QuantityProduct { get; set; }
        public int ToppingID { get; set; }
        public Toppings Toppings { get; set; }
        public int QuantityTopping { get; set; }
        public int UserID { get; set; }
        public Users Users { get; set; }
        public int SizeID { get; set; }
        public Sizes Sizes { get; set; }

    }
}
