using HRS.Business.Abstract;
using HRS.Business.Concrete;
using HRS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IReservationService _reservationService;
        public HomeController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<int> peopleList = new List<int>();
            peopleList = Enum.GetValues(typeof(Room)).Cast<int>().ToList();
            return View(peopleList);
        }

        [HttpPost]
        public JsonResult Calculator(ReservationModel model)
        {
            if (model.CheckIn < DateTime.Now.AddDays(-1) || model.CheckIn > model.CheckOut)
            {
                return Json(new ReservationModel());
            }
            model.TotalPrice = _reservationService.Calc(model);
            return Json(model);
        }
        [HttpPost]
        public ActionResult AddReservation(ReservationModel model)
        {
            if(model.CheckIn<DateTime.Now.AddDays(-1) || model.CheckIn > model.CheckOut)
            {
                return Json("Hata");
            }
            _reservationService.Add(model);
            return Json("Başarılı");
        }
    }
}