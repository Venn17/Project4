using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Models
{
    [Table("tblHistorys")]
    public class Historys
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public Users Users { get; set; }
        public int CartID { get; set; }
        public Carts Carts { get; set; }
        public int Payment { get; set; }
        public int CouponID { get; set; }
        public Coupons Coupons { get; set; }
        public int Status { get; set; }
    }
}
