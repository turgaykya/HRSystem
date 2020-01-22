using HRS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Data.Concrete.EntityFramework
{
    public class HRSContext : DbContext
    {
        public HRSContext() : base("name=HRSContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Pricing> Pricing{ get; set; }
    }
}
