using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CicleFem1.Models;

namespace CicleFem1.Controllers
{
    public class DettaglioSchedasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DettaglioSchedas
        public ActionResult Index()
        {
            return View(db.DettaglioSchedas.ToList());
        }

        // GET: DettaglioSchedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettaglioScheda dettaglioScheda = db.DettaglioSchedas.Find(id);
            if (dettaglioScheda == null)
            {
                return HttpNotFound();
            }
            return View(dettaglioScheda);
        }

        // GET: DettaglioSchedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DettaglioSchedas/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DettaglioScheda_Id,Data,Giorno,Temperatura,Scheda_Id,Ematic,Muco,MucoC,Coito,UteCon,UteInc,UteApe,UtePos,Note")] DettaglioScheda dettaglioScheda)
        {
            if (ModelState.IsValid)
            {
                db.DettaglioSchedas.Add(dettaglioScheda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dettaglioScheda);
        }

        // GET: DettaglioSchedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettaglioScheda dettaglioScheda = db.DettaglioSchedas.Find(id);
            if (dettaglioScheda == null)
            {
                return HttpNotFound();
            }
            return View(dettaglioScheda);
        }

        // POST: DettaglioSchedas/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DettaglioScheda_Id,Data,Giorno,Temperatura,Scheda_Id,Ematic,Muco,MucoC,Coito,UteCon,UteInc,UteApe,UtePos,Note")] DettaglioScheda dettaglioScheda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dettaglioScheda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Schedas", new { id = dettaglioScheda.Scheda_Id });
            }
            return View(dettaglioScheda);
        }

        // GET: DettaglioSchedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettaglioScheda dettaglioScheda = db.DettaglioSchedas.Find(id);
            if (dettaglioScheda == null)
            {
                return HttpNotFound();
            }
            return View(dettaglioScheda);
        }

        // POST: DettaglioSchedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DettaglioScheda dettaglioScheda = db.DettaglioSchedas.Find(id);
            db.DettaglioSchedas.Remove(dettaglioScheda);
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
