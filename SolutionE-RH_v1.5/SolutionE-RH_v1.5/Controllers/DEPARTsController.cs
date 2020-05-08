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
    public class DEPARTsController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: DEPARTs
        public ActionResult Index()
        {
            var dEPARTs = db.DEPARTs.Include(d => d.EMPLOYEE);
            return View(dEPARTs.ToList());
        }

        // GET: DEPARTs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPART dEPART = db.DEPARTs.Find(id);
            if (dEPART == null)
            {
                return HttpNotFound();
            }
            return View(dEPART);
        }

        // GET: DEPARTs/Create
        public ActionResult Create()
        {
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN");
            return View();
        }

        // POST: DEPARTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEP,MATRECULE,DATE_DEP,MOTIF_DEP")] DEPART dEPART)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTs.Add(dEPART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEPART.MATRECULE);
            return View(dEPART);
        }

        // GET: DEPARTs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPART dEPART = db.DEPARTs.Find(id);
            if (dEPART == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEPART.MATRECULE);
            return View(dEPART);
        }

        // POST: DEPARTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEP,MATRECULE,DATE_DEP,MOTIF_DEP")] DEPART dEPART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEPART.MATRECULE);
            return View(dEPART);
        }

        // GET: DEPARTs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPART dEPART = db.DEPARTs.Find(id);
            if (dEPART == null)
            {
                return HttpNotFound();
            }
            return View(dEPART);
        }

        // POST: DEPARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DEPART dEPART = db.DEPARTs.Find(id);
            db.DEPARTs.Remove(dEPART);
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
