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
    public class DEPLACEMENTsController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: DEPLACEMENTs
        public ActionResult Index()
        {
            var dEPLACEMENTs = db.DEPLACEMENTs.Include(d => d.EMPLOYEE);
            return View(dEPLACEMENTs.ToList());
        }

        // GET: DEPLACEMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPLACEMENT dEPLACEMENT = db.DEPLACEMENTs.Find(id);
            if (dEPLACEMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPLACEMENT);
        }

        // GET: DEPLACEMENTs/Create
        public ActionResult Create()
        {
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN");
            return View();
        }

        // POST: DEPLACEMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEPLACEMENT,MATRECULE,DATE_DEPART,DATE_RETOUR,DESTINATION,FRAIS_DEP,MOYENS_DEP,Avis_dep")] DEPLACEMENT dEPLACEMENT)
        {
            if (ModelState.IsValid)
            {
                db.DEPLACEMENTs.Add(dEPLACEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEPLACEMENT.MATRECULE);
            return View(dEPLACEMENT);
        }

        // GET: DEPLACEMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPLACEMENT dEPLACEMENT = db.DEPLACEMENTs.Find(id);
            if (dEPLACEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEPLACEMENT.MATRECULE);
            return View(dEPLACEMENT);
        }

        // POST: DEPLACEMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEPLACEMENT,MATRECULE,DATE_DEPART,DATE_RETOUR,DESTINATION,FRAIS_DEP,MOYENS_DEP,Avis_dep")] DEPLACEMENT dEPLACEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPLACEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEPLACEMENT.MATRECULE);
            return View(dEPLACEMENT);
        }

        // GET: DEPLACEMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPLACEMENT dEPLACEMENT = db.DEPLACEMENTs.Find(id);
            if (dEPLACEMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPLACEMENT);
        }

        // POST: DEPLACEMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPLACEMENT dEPLACEMENT = db.DEPLACEMENTs.Find(id);
            db.DEPLACEMENTs.Remove(dEPLACEMENT);
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
