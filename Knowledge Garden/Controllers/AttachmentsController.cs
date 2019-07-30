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

        // GET: Attachments/Details/5
        public ActionResult Details(int? flowerId, string attachmentName)
        {
            if (flowerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = uow.Attachments.Find(flowerId, attachmentName);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: Attachments/Create
        public ActionResult Create(int flowerId)
        {
            ViewBag.FlowerId = flowerId;
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlowerId,Name,blobValue")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                if (!IsOwnedAttachment(attachment))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                uow.Attachments.Add(attachment);
                return RedirectToAction("Details", "Flowers", attachment.FlowerId);
            }

            ViewBag.FlowerId = attachment.FlowerId;
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public ActionResult Delete(int? flowerId, string attachmentName)
        {
            if (flowerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Check that attachment exists
            Attachment attachment = uow.Attachments.Find(flowerId, attachmentName);
            if (attachment == null)
            {
                return HttpNotFound();
            }

            if (!IsOwnedAttachment(attachment))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
        public ActionResult DeleteConfirmed(AttachmentViewModel attachmentVM)
        {
            Attachment attachment = uow.Attachments.Find(attachmentVM.FlowerId, attachmentVM.Name);
            uow.Attachments.Remove(attachment);
            return RedirectToAction("Details", "Flowers", attachmentVM.FlowerId);
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
        /// <returns></returns>
        private bool IsOwnedAttachment(Attachment attachment)
        {
            return uow.Flowers.Find(attachment.FlowerId).OwnerUsername == User.Identity.Name;
        }
    }
}
