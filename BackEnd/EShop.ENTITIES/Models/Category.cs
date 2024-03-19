using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ENTITIES.Models
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryID { get; set; } //Kategoriler arası ilişki için 

        //Relation Property
        public virtual ICollection<Product> Products { get; set; }

    }
}
