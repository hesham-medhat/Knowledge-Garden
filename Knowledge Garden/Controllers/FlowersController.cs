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
    public class FlowersController : Controller
    {
        private IUnitOfWork uow = new UnitOfWork();

        // GET: Flowers
        public ActionResult Index()
        {
            return View(uow.Flowers.GetAllFlowers());
        }

        // GET: Flowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = uow.Flowers.GetFlower(id.Value);
            if (flower == null)
            {
                return HttpNotFound();
            }
            // Generate display view model
            FlowerDisplayViewModel displayFlower = FlowerViewModelFactory.CreateDisplayModel(flower);
            return View(displayFlower);
        }

        // GET: Flowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Problem,Solution")] FlowerAddOrEditViewModel flowerModel)
        {
            if (ModelState.IsValid)
            {
                uow.Flowers.AddFlower(
                    editorUsername: User.Identity.Name,
                    problem: flowerModel.Problem,
                    solution: flowerModel.Solution,
                    title: flowerModel.Title
                    );
                return RedirectToAction("Index");
            }

            return View(flowerModel);
        }

        // GET: Flowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Flower flower = uow.Flowers.GetFlower(id.Value);
            if (flower == null)
            {
                return HttpNotFound();
            }
            else if (!IsOwner(flower))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the flower you requested to edit");
            }

            var flowerModel = FlowerViewModelFactory.CreateAddOrEditViewModel(flower);
            return View(flowerModel);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Problem,Solution")] FlowerAddOrEditViewModel flowerModel)
        {
            if (!IsOwner(flowerModel.Id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the flower you requested to edit");
            }

            if (ModelState.IsValid)
            {
                uow.Flowers.EditFlower(
                    editorUsername: User.Identity.Name,
                    flowerId: flowerModel.Id,
                    problem: flowerModel.Problem,
                    solution: flowerModel.Solution,
                    title: flowerModel.Title);
                return RedirectToAction("Index");
            }
            return View(flowerModel);
        }

        // GET: Flowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Flower flower = uow.Flowers.GetFlower(id.Value);
            if (flower == null)
            {
                return HttpNotFound();
            }
            else if (!IsOwner(flower))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the flower you request to delete");
            }

            var flowerModel = FlowerViewModelFactory.CreateAddOrEditViewModel(flower);
            return View(flowerModel);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!IsOwner(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You do not own the flower you requested to delete");
            }
            uow.Flowers.RemoveFlower(id);
            return RedirectToAction("Index");
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


        private bool IsOwner(Flower flower)
        {
            return flower.OwnerUsername == User.Identity.Name;
        }

        private bool IsOwner(int flowerId)
        {
            return IsOwner(uow.Flowers.Find(flowerId));
        }
    }
}
