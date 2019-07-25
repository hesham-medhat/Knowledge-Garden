using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Knowledge_Garden.Engine.Data;
using Knowledge_Garden.Engine.Models;
using Knowledge_Garden.Models;

namespace Knowledge_Garden.Controllers
{
    public class FlowersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Flowers
        public ActionResult Index()
        {
            return View(db.Flowers.ToList());
        }

        // GET: Flowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = db.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            // Generate display view model
            FlowerDisplayViewModel displayFlower = FlowerViewModelFactory.CreateDisplayModel(flower, flower.Owner.Username);
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
                var flower = new Flower
                {
                    LastUpdateDate = DateTime.Now,
                    Owner = db.Employees.Find(User.Identity.Name),
                    Problem = flowerModel.Problem,
                    Solution = flowerModel.Solution,
                    Title = flowerModel.Title
                };
                db.Flowers.Add(flower);
                db.SaveChanges();
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
            Flower flower = db.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
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
            if (ModelState.IsValid)
            {
                var flower = new Flower {
                    LastUpdateDate = DateTime.Now,
                    Owner = db.Employees.Find(User.Identity.Name),
                    Problem = flowerModel.Problem,
                    Solution = flowerModel.Solution,
                    Title = flowerModel.Title
                };
                db.Entry(flower).State = EntityState.Modified;
                db.SaveChanges();
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
            Flower flower = db.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            var flowerModel = FlowerViewModelFactory.CreateAddOrEditViewModel(flower);
            return View(flowerModel);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flower flower = db.Flowers.Find(id);
            db.Flowers.Remove(flower);
            db.SaveChanges();
            return RedirectToAction("Index");
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
