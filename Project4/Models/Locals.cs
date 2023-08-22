using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblLocals")]
    public class Locals
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
