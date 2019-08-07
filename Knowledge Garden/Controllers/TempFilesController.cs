using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Knowledge_Garden.Engine.DataAccess;
using Knowledge_Garden.Engine.Models;
using Knowledge_Garden.Models;

namespace Knowledge_Garden.Controllers
{
    [Authorize]
    public class TempFilesController : Controller
    {
        private IUnitOfWork uow = new UnitOfWork();

        // GET: TempFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempFile file = uow.TempFiles.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }

            /* Validate user is the owner of this file */
            Request request = uow.Requests.Find(file.RequestId);
            if (request.OwnerUsername != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own this file");
            }

            Response.AppendHeader("content-disposition", "inline; filename=" + file.Name);

            return File(file.blobValue, file.ContentType);
        }

        // GET: TempFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase fileBase)
        {
            // Obtain request from session
            int? rId = (int?) Session["RID"];
            if (rId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Your session isn't undergoing a request to perform this action");
            }
            int requestId = rId.Value;
            Request request = uow.Requests.Find(requestId);
            if (request == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Try another request session");
            }

            // Confirm user issued that request
            if (request.OwnerUsername != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own this file");
            }

            if (ModelState.IsValid)
            {
                // HttpPostedFileBase fileBase = fileVM.FileBase;
                // Determine if legal file type
                switch (fileBase.ContentType)
                {
                    case "application/vnd.microsoft.portable-executable":
                    case "application/octet-stream":
                    case "application/x-msdownload":
                        return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Cannot upload executables");
                    default: break;
                }

                // Build TempFile
                TempFile tempFile = new TempFile
                {
                    ContentType = fileBase.ContentType,
                    Name = fileBase.FileName,
                    RequestId = requestId,
                    Request = request
                };
                tempFile.blobValue = new byte[fileBase.ContentLength];
                fileBase.InputStream.Read(tempFile.blobValue, 0, (fileBase.ContentLength));

                uow.TempFiles.Add(tempFile);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "File saved. You may return back now.");
            }

            return View();
        }
        
        // GET: TempFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Obtain request from session
            int? rId = (int?)Session["RID"];
            if (rId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Your session isn't undergoing a request to perform this action");
            }
            int requestId = rId.Value;
            Request request = uow.Requests.Find(requestId);
            if (request == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Try another request session");
            }

            // Confirm user issued that request
            if (request.OwnerUsername != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own this file");
            }

            // Fetch file if exists
            TempFile tempFile = uow.TempFiles.Find(id);
            if (tempFile == null)
            {
                return HttpNotFound();
            }
            return View(tempFile);
        }

        // POST: TempFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Obtain request from session
            int? rId = (int?)Session["RID"];
            if (rId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Your session isn't undergoing a request to perform this action");
            }
            int requestId = rId.Value;
            Request request = uow.Requests.Find(requestId);
            if (request == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Try another request session");
            }

            // Confirm user issued that request
            if (request.OwnerUsername != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own this file");
            }

            // Fetch file if exists
            TempFile tempFile = uow.TempFiles.Find(id);
            if (tempFile == null)
            {
                return HttpNotFound();
            }

            uow.TempFiles.Remove(tempFile);
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Delete confirmed.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.SaveAndDispose();
            }
            base.Dispose(disposing);
        }
    }
}
