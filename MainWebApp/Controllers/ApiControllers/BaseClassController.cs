using MyDatabase;
using RepositoryService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWebApp.Controllers.ApiControllers
{
    public class BaseClassController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected UnitOfWork unit;

        public BaseClassController()
        {
            unit = new UnitOfWork(db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}