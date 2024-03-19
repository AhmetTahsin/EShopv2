﻿using EShop.BLL.DTOs.DTOClasesses;
using EShop.BLL.DTOs.DTOClasesses.EntitysDTO;
using EShop.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.ManagerServices.Abstracts
{
    public interface ICategoryManager:IManager<CategoryDTO,Category>
    {
        public string Sil(string name);
    }
}
