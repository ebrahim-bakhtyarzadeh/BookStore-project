﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Query.Sellers.Inventories.GetById;
public record GetSellerInventoryByIdQuery(long inventoryId):IQuery<InventoryDto?>;
