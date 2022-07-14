using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Entities;
using MyDatabase;
using RepositoryService.Persistance;

namespace MainWebApp.Controllers.ApiControllers
{
    public class ForceUserApiController : BaseClassController
    {

        [HttpGet]
        public ActionResult GetAllForceUsers()
        {
            var forceUsers = unit.ForceUsers.GetAll();

            if (forceUsers != null)
            {
                return Json(forceUsers, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }


        [HttpGet]
        public ActionResult GetForceUserById(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var forceUser = unit.ForceUsers.GetById(id);

            if (forceUser is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return Json(forceUser, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult InsertForceUser(ForceUser forceUser)
        {
            if (ModelState.IsValid)
            {
                unit.ForceUsers.Insert(forceUser);
                unit.ForceUsers.Save();
                return Json(forceUser, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [HttpPost]
        //[Route("/ForceUserApi/DeleteForceUserById?{id}")]
        public ActionResult DeleteForceUserById(int? id) 
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var forceUser = unit.ForceUsers.GetById(id);

            if (forceUser is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            unit.ForceUsers.Delete(forceUser.ForceUserId);
            unit.ForceUsers.Save();

            return Json(forceUser, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UpdateForceUser(int? id, ForceUser forceUser)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var forceUsr = unit.ForceUsers.GetById(id);

            if (forceUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            forceUsr.FirstName = forceUser.FirstName;
            forceUsr.LastName = forceUser.LastName;
            forceUsr.Specialiazation = forceUser.Specialiazation;
            forceUsr.PhotoUrl = forceUser.PhotoUrl;
            forceUsr.Midichlorians = forceUser.Midichlorians;
            forceUsr.Side = forceUser.Side;
            forceUsr.Rank = forceUser.Rank;
            forceUsr.Deceased = forceUser.Deceased;

            if (ModelState.IsValid)
            {
                unit.ForceUsers.Update(forceUsr);
                unit.ForceUsers.Save();
                return Json(forceUsr, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}