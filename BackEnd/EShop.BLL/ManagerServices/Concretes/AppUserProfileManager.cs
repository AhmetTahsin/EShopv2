using AutoMapper;
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
    public class AppUserProfileManager : BaseManager<AppUserProfileDTO, AppUserProfile>, IAppUserProfileManager
    {
        IAppUserProfileRepository _aUPrep;
        IMapper _mapper;
        public AppUserProfileManager(IAppUserProfileRepository aUPrep, IMapper mapper) : base(aUPrep, mapper)
        {
            _aUPrep = aUPrep;
            _mapper = mapper;
        }
    }
}
