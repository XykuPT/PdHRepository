using PdH.Entities;
using System;
using System.Collections.Generic;

namespace PdH.Business.Interfaces
{
    public interface ISalesBc
    {
        Sales Add(Sales sales);

        Sales Get(long id);

        IEnumerable<Sales> Search(
            int pageNumber,
            int pageSize,
            string productCode = null,
            long? customerKey = null,
            DateTime? saleDate = null);

        long Count(
            string productCode,
            long? customerKey,
            DateTime? saleDate);
    }
}
