﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API.DTO;

namespace DataAccessLayer.API
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetByName(string name);
    }
}
