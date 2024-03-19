using AutoMapper;
using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.DTOs.DTOClasesses.EntitysDTO;
using EShop.BLL.ManagerServices.Abstracts;
using EShop.DAL.Repositories.Abstracts;
using EShop.DAL.Repositories.Concretes;
using EShop.ENTITIES.CoreInterfaces;
using EShop.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager<CategoryDTO,Category>, ICategoryManager
    {
       // protected IRepository<IEntity> _repository;
        ICategoryRepository _catRep;
        IMapper _mapper;
        public CategoryManager(ICategoryRepository catRep, IMapper mapper) : base(catRep, mapper) //??
        {
            _mapper = mapper;
            _catRep = catRep;
        }

        public string Sil(string name) //Açık olurmus bak
        {
            var category=_catRep.FirstOrDefault(x=>x.CategoryName == name);
            //_iRep.Delete(category); Delete Test Edildi

            return "Silindi";
        }
        //Burada IRepository<IEntity> kullanmamız lazım önemli !!


    }
}
