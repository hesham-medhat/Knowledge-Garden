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
    public class AttachmentsController : Controller
    {
        private IUnitOfWork uow = new UnitOfWork();


        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Flower id not specified");
            }
            ViewBag.flowerId = id.Value;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int flowerId, HttpPostedFileBase fileBase)
        {
            // Get requested flower
            Flower flower = uow.Flowers.Find(flowerId);
            if (flower == null)
            {
                return HttpNotFound("Flower doesn't exist");
            }

            // Confirm user owns that flower
            if (flower.OwnerUsername != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You cannot add an attachment to a flower you don't own");
            }

            // Determine if legal file type
            switch (fileBase.ContentType)
            {
                case "application/vnd.microsoft.portable-executable":
                case "application/octet-stream":
                case "application/x-msdownload":
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Cannot upload executables");
                default: break;
            }

            // Build attachment
            Attachment newAttachment = new Attachment
            {
                ContentType = fileBase.ContentType,
                Name = fileBase.FileName,
                Flower = flower
            };
            newAttachment.blobValue = new byte[fileBase.ContentLength];
            fileBase.InputStream.Read(newAttachment.blobValue, 0, (fileBase.ContentLength));

            uow.Attachments.Add(newAttachment);

            // All good. Terminate.
            return RedirectToAction("Index", new { id = flowerId });
        }
        
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Not given an ID for the flower whose attachments are requested");
            }
            // Get requested flower
            Flower flower = uow.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }

            if (flower.OwnerUsername != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the flower in question");
            }

            // Build view
            ViewBag.flowerId = id;
            return View(flower.Attachments);
        }

        [Route("Attachments/Details/{flowerId?}/{attachmentName}")]
        public ActionResult Details(int? flowerId, string attachmentName)
        {
            if (flowerId == null || attachmentName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Missing parameters for the request.");
            }
            Attachment attachment = uow.Attachments.Find(flowerId, attachmentName);
            if (attachment == null)
            {
                return HttpNotFound();
            }

            Response.AppendHeader("content-disposition", "inline; filename=" + attachment.Name);

            return File(attachment.blobValue, attachment.ContentType);
        }

        [Route("Attachments/Delete/{flowerId}/{attachmentName}")]
        public ActionResult Delete(int? flowerId, string attachmentName)
        {
            if (flowerId == null || attachmentName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Missing parameters for the request.");
            }

            // Check that attachment exists
            Attachment attachment = uow.Attachments.Find(flowerId, attachmentName);
            if (attachment == null)
            {
                return HttpNotFound();
            }

            if (!IsOwnedAttachment(attachment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the file you request to delete");
            }
            
            // Build view model
            AttachmentViewModel attachmentViewModel = new AttachmentViewModel
            {
                FlowerId = flowerId.Value,
                Name = attachmentName
            };
            return View(attachmentViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int flowerId, string attachmentName)
        {
            Attachment attachment = uow.Attachments.Find(flowerId, attachmentName);
            if (!IsOwnedAttachment(attachment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the file you request to delete");
            }
            uow.Attachments.Remove(attachment);
            return RedirectToAction("Details", "Flowers", new { id = flowerId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Save();
                uow.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Verifies that the attachment in question is owned by the current logged in user
        /// in order to verify the integrity of the action's request
        /// </summary>
        /// <param name="attachment">The attachment object in question used for getting 
        /// the FlowerId property</param>
        private bool IsOwnedAttachment(Attachment attachment)
        {
            return uow.Flowers.Find(attachment.FlowerId).OwnerUsername == User.Identity.Name;
        }
    }
}
