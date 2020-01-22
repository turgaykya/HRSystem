using HRS.Business.Concrete;
using HRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Business.Abstract
{
    public interface IReservationService
    {
        void Add(ReservationModel Entity);

        decimal Calc(ReservationModel Entity);

    }
}
