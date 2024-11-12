using Common.Query;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetByUserId;
public record GetSellerByUserIdQuery(long userId):IQuery<SellerDto>
{

}
