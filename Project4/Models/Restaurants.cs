using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblRestaurants")]
    public class Restaurants
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Quality { get; set; }
        public int LocalID { get; set; }
        public Locals Locals { get; set; }
        public bool Status { get; set; }
    }
}
