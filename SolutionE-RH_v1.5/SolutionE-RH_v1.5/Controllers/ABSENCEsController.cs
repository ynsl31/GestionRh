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
    public class ABSENCEsController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: ABSENCEs
        public ActionResult Index()
        {
            var aBSENCEs = db.ABSENCEs.Include(a => a.EMPLOYEE);
            return View(aBSENCEs.ToList());
        }

        // GET: ABSENCEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABSENCE aBSENCE = db.ABSENCEs.Find(id);
            if (aBSENCE == null)
            {
                return HttpNotFound();
            }
            return View(aBSENCE);
        }

        // GET: ABSENCEs/Create
        public ActionResult Create()
        {
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN");
            return View();
        }

        // POST: ABSENCEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ABS,MATRECULE,DATE,NB_JOUR,JUSTIFIER,RAIS_ABS")] ABSENCE aBSENCE)
        {
            if (ModelState.IsValid)
            {
                db.ABSENCEs.Add(aBSENCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", aBSENCE.MATRECULE);
            return View(aBSENCE);
        }

        // GET: ABSENCEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABSENCE aBSENCE = db.ABSENCEs.Find(id);
            if (aBSENCE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", aBSENCE.MATRECULE);
            return View(aBSENCE);
        }

        // POST: ABSENCEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ABS,MATRECULE,DATE,NB_JOUR,JUSTIFIER,RAIS_ABS")] ABSENCE aBSENCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aBSENCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", aBSENCE.MATRECULE);
            return View(aBSENCE);
        }

        // GET: ABSENCEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABSENCE aBSENCE = db.ABSENCEs.Find(id);
            if (aBSENCE == null)
            {
                return HttpNotFound();
            }
            return View(aBSENCE);
        }

        // POST: ABSENCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ABSENCE aBSENCE = db.ABSENCEs.Find(id);
            db.ABSENCEs.Remove(aBSENCE);
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
