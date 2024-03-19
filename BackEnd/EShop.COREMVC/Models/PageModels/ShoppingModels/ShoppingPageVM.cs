using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.DTOs.DTOClasesses.EntitysDTO;
using EShop.ENTITIES.Models;
using X.PagedList;

namespace EShop.COREMVC.Models.PageModels.ShoppingModels
{
    public class ShoppingPageVM
    {
        public IPagedList<ProductDTO> Products { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}
