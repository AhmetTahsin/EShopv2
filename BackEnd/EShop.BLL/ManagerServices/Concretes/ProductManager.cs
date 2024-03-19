using AutoMapper;
using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.DTOs.DTOClasesses.EntitysDTO;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.DAL.Repositories.Abstracts;
using EShop.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ManagerServices.Concretes
{
    public class ProductManager:BaseManager<ProductDTO,Product>,IProductManager
    {
        IProductRepository _proRep;
        IMapper _mapper;
        public ProductManager(IProductRepository proRep,IMapper mapper):base(proRep,mapper)
        {
            _proRep = proRep;
            _mapper = mapper;
        }
    }
}
