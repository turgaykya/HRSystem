using HRS.Core.Data.EntitiyFramework;
using HRS.Data.Abstract;
using HRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Data.Concrete.EntityFramework
{
    public class EfPricingDal : EfEntityRepositoryBase<Pricing, HRSContext>, IPricingDal
    {
    }
}
