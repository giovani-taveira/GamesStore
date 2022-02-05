﻿using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Interface
{
    public interface ISaleService
    {
        List<Sale> GetAll();
        bool AddNewSale(int gameId, AddSaleInputModel model);
        bool DeleteSale(int saleId);
        bool DeleteSale();
    }
}
