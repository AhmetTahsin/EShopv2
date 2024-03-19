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
    public class OrderManager : BaseManager<OrderDTO, Order>, IOrderManager
    {
        IOrderRepository _orRep;
        IMapper _mapper;

        public OrderManager(IOrderRepository iRep, IMapper mapper) : base(iRep, mapper)
        {
            _orRep = iRep;
            _mapper = mapper;
        }
    }
}
