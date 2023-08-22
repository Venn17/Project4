using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblLogined")]
    public class Logined
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public Users Users { get; set; }
    }
}
