using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdH.Business.Interfaces
{
    public interface ISaleDetailsBc
    {
        SaleDetails Add(SaleDetails saleDetail);
    }
}
