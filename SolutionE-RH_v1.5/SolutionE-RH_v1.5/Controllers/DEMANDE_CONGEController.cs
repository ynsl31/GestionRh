using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionE_RH_v1._5.Models;

namespace SolutionE_RH_v1._5.Controllers
{
    public class DEMANDE_CONGEController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: DEMANDE_CONGE
        public ActionResult Index()
        {
            var dEMANDE_CONGE = db.DEMANDE_CONGE.Include(d => d.EMPLOYEE);
            return View(dEMANDE_CONGE.ToList());
        }

        // GET: DEMANDE_CONGE/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMANDE_CONGE dEMANDE_CONGE = db.DEMANDE_CONGE.Find(id);
            if (dEMANDE_CONGE == null)
            {
                return HttpNotFound();
            }
            return View(dEMANDE_CONGE);
        }

        // GET: DEMANDE_CONGE/Create
        public ActionResult Create()
        {
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN");
            return View();
        }

        // POST: DEMANDE_CONGE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEMANDE,MATRECULE,PERIODE,DATE_DEBUT,FICHIER_JUST")] DEMANDE_CONGE dEMANDE_CONGE, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
           


                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                    file.SaveAs(path);

                    dEMANDE_CONGE.FICHIER_JUST = fileName;
                    db.DEMANDE_CONGE.Add(dEMANDE_CONGE);
                        db.SaveChanges();
                }

                
                return RedirectToAction("Index");
            }

            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEMANDE_CONGE.MATRECULE);
            return View(dEMANDE_CONGE);
        }

        // GET: DEMANDE_CONGE/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMANDE_CONGE dEMANDE_CONGE = db.DEMANDE_CONGE.Find(id);
            if (dEMANDE_CONGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEMANDE_CONGE.MATRECULE);
            return View(dEMANDE_CONGE);
        }

        // POST: DEMANDE_CONGE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEMANDE,MATRECULE,DATE_ENVOI,PERIODE,DATE_DEBUT,FICHIER_JUST")] DEMANDE_CONGE dEMANDE_CONGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEMANDE_CONGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", dEMANDE_CONGE.MATRECULE);
            return View(dEMANDE_CONGE);
        }

        // GET: DEMANDE_CONGE/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEMANDE_CONGE dEMANDE_CONGE = db.DEMANDE_CONGE.Find(id);
            if (dEMANDE_CONGE == null)
            {
                return HttpNotFound();
            }
            return View(dEMANDE_CONGE);
        }

        // POST: DEMANDE_CONGE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DEMANDE_CONGE dEMANDE_CONGE = db.DEMANDE_CONGE.Find(id);
            db.DEMANDE_CONGE.Remove(dEMANDE_CONGE);
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
