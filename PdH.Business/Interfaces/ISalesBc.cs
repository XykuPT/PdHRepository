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
            long? customerKey = null,
            DateTime? saleDate = null);

        long Count(long? customerKey, DateTime? saleDate);
    }
}
