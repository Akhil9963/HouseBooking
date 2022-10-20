using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTypeController : ControllerBase
    {
        BookingDbcontext context;

        public object ViewBag { get; private set; }

        public BookingTypeController(BookingDbcontext context)
        {
            this.context = context;
        }

        public BookingTypeController()
        {
        }

        public ActionResult Index()
        {
            return View(context.BookingType.ToList());
        }

        private ActionResult View(object value)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "", Value = "" });
            List<SelectListItem> peoples = new List<SelectListItem>();
            return View(new BookingTypeViewModel());
        }

        private ActionResult View(BookingTypeViewModel bookingTypeViewModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookingTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                BookingType obj = new BookingType();
                context.BookingType.Add(obj);
                await context.SaveChangesAsync();
            }
            return View(model);
        }
    }

    internal class ViewBag
    {
    }
}

       
