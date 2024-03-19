using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.DTOs.DTOClasesses
{
    public class NewPasswordViewDTO
    {
        public Guid SpecId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
