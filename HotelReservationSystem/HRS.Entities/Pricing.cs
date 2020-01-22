using HRS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Entities
{
    public class Pricing : IEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int WeekType { get; set; }
    }
}
