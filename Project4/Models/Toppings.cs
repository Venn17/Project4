using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblToppings")]
    public class Toppings
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductID { get; set; }
        public Products Products { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
    }
}
