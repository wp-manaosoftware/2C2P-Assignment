using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.DomainModels.Transactions
{
    public enum Status
    {
        Success,
        Failed,
        Canceled
    }
}
