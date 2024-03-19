using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public string ShippingAddress { get; set; } 
        public string Email { get; set; }   //Üye olmayanda sipariş verebilir !
        public string NameDescription { get; set; } //Üye olmayanda sipariş verebilir !
        public int? AppUserID { get; set; } 
        public decimal PriceOfOrder { get; set; }
        //Relation Property
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
