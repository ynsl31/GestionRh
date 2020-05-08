using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionE_RH_v1._5.Models;

namespace SolutionE_RH_v1._5.Controllers
{
    public class FORMATIONsController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: FORMATIONs
        public ActionResult Index()
        {
            return View(db.FORMATIONs.ToList());
        }

        // GET: FORMATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMATION fORMATION = db.FORMATIONs.Find(id);
            if (fORMATION == null)
            {
                return HttpNotFound();
            }
            return View(fORMATION);
        }

        // GET: FORMATIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FORMATIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REF_FORMATION,LIB,DATE_DEPUT,NB_JOUR,NB_PARTICIPE,DESC_SUJET,NOM_FORMATEUR")] FORMATION fORMATION)
        {
            if (ModelState.IsValid)
            {
                db.FORMATIONs.Add(fORMATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fORMATION);
        }

        // GET: FORMATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMATION fORMATION = db.FORMATIONs.Find(id);
            if (fORMATION == null)
            {
                return HttpNotFound();
            }
            return View(fORMATION);
        }

        // POST: FORMATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REF_FORMATION,LIB,DATE_DEPUT,NB_JOUR,NB_PARTICIPE,DESC_SUJET,NOM_FORMATEUR")] FORMATION fORMATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fORMATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fORMATION);
        }

        // GET: FORMATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMATION fORMATION = db.FORMATIONs.Find(id);
            if (fORMATION == null)
            {
                return HttpNotFound();
            }
            return View(fORMATION);
        }

        // POST: FORMATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FORMATION fORMATION = db.FORMATIONs.Find(id);
            db.FORMATIONs.Remove(fORMATION);
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
