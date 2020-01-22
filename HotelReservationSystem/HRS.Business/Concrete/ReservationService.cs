using HRS.Business.Abstract;
using HRS.Data.Abstract;
using HRS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Business.Concrete
{
    public class ReservationService : IReservationService
    {
        public IReservationDal _reservationDal;
        public IPricingDal _pricingDal;
        public ReservationService(IReservationDal reservationDal, IPricingDal pricingDal)
        {
            _reservationDal = reservationDal;
            _pricingDal = pricingDal;
        }


        public enum RoomTypeEnum
        {
            OnePeople = 1,
            TwoPeople = 2,
            ThreePeople = 3
        }
        public enum WeekTypeEnum
        {
            WeekDays = 1,
            Weekend = 2

        }



        public void Add(ReservationModel Entity)
        {
            Reservation reservation = new Reservation()
            {
                CheckIn = Entity.CheckIn,
                CheckOut = Entity.CheckOut,
                FullName = Entity.FullName,
                NumberOfPeople = Entity.NumberOfPeople,
                TotalPrice = Entity.TotalPrice
            };
            _reservationDal.Add(reservation);
        }


        public decimal Calc(ReservationModel Entity)
        {
            var diff = Entity.CheckOut.Day - Entity.CheckIn.Day + 1;
            var weekend = CalcWeekend(Entity.CheckIn, Entity.CheckOut, diff);
            var weekday = diff - weekend;
            decimal pricingWeekDays = 0, pricesWeekend = 0;
            pricingWeekDays = _pricingDal.Get(x => x.WeekType == 1).Price;
            pricesWeekend = _pricingDal.Get(x => x.WeekType == 2).Price;
            var calc = (pricingWeekDays * weekday) + (pricesWeekend * weekend);
            switch (Entity.NumberOfPeople)
            {

                case (int)RoomTypeEnum.OnePeople:
                    Entity.TotalPrice = (calc) - (calc * 30 / 100);
                    break;
                case (int)RoomTypeEnum.TwoPeople:
                    Entity.TotalPrice = calc;
                    break;
                case (int)RoomTypeEnum.ThreePeople:
                    Entity.TotalPrice = calc + (calc * 20 / 100);
                    break;
            }


            return Entity.TotalPrice;
        }

        private int CalcWeekend(DateTime checkin, DateTime checkout, int diff)
        {
            var counter = 0;
            for (int i = 0; i < diff; i++)
            {
                switch (checkin.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        counter++;
                        break;
                    case DayOfWeek.Sunday:
                        counter++;
                        break;
                }
                checkin = checkin.AddDays(1);
            }
            return counter;
        }
    }
}
