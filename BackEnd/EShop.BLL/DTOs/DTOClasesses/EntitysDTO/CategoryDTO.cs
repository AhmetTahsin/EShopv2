using EShop.BLL.DTOs.DTOClasesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.DTOs.DTOClasesses.EntitysDTO
{
    public class CategoryDTO:BaseDTO
    {
        
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
