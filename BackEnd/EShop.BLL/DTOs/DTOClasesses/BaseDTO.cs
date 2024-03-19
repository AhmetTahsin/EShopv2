using EShop.BLL.DTOs.CoreInterfaces;
using EShop.ENTITIES.Enums;
using EShop.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.DTOs.DTOClasesses
{
    public abstract class BaseDTO: IDTO //Todo:CreatedDate 
    {
        public BaseDTO()//Todo:CreatedDate degisiyor bak !
        {
            ModifiedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}
