using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CicleFem1.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace CicleFem1.Controllers
{
    [Authorize]
    public class SchedasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "dd/MM/yy" };

        // GET: Schedas
        public ActionResult Index()
        {
            var ut = User.Identity.GetUserId();
            return View(db.Schedas.Where(u => u.Uid == ut).OrderByDescending(d => d.DataI).ToList());
        }

        public ActionResult IndexUt()
        {
            var ut = User.Identity.GetUserId();
            return View(db.Schedas.Where(u=>u.Uid == ut).OrderByDescending(d => d.DataI).ToList());
        }

        // GET: Schedas/Details/5e
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheda scheda = db.Schedas.Find(id);
            if (scheda == null)
            {
                return HttpNotFound();
            }
            var dati = db.DettaglioSchedas.Where(s => s.Scheda_Id == id).Select(s => new { g = s.Giorno, t = s.Temperatura, m = s.Muco, mc = s.MucoC, e = s.Ematic, d = s.Data }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dati, _jsonSetting);
            return View(scheda);
        }

        public ActionResult TestChart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheda scheda = db.Schedas.Find(id);
            if (scheda == null)
            {
                return HttpNotFound();
            }
            var dati = db.DettaglioSchedas.Where(s => s.Scheda_Id == id).Select(s => new { g = s.Giorno, t = s.Temperatura, m = s.Muco, e = s.Ematic, d = s.Data }).ToList();
            ViewBag.DataPoints = JsonConvert.SerializeObject(dati, _jsonSetting);
            return View(scheda);
        }

        // GET: Schedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedas/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Scheda_Id,Numero,NumeroG,DataI,DataF,Uid")] Scheda scheda, [Bind(Include = "DettaglioScheda_Id,Data,Giorno,Temperatura,Scheda_Id")] DettaglioScheda dettaglioScheda)
        {
            var ut = User.Identity.GetUserId();
            scheda.Uid = ut;
            var num = db.Schedas.Where(u => u.Uid == ut).Max(n => n.Numero);
            if(num != null)
            {
            scheda.Numero = num + 1;
            }
            else
            {
                scheda.Numero = 1;
            }
            var inizio = scheda.DataI;
            var giorni = scheda.NumeroG;
            if (ModelState.IsValid)
            {
                db.Schedas.Add(scheda);
                db.SaveChanges();
                //Creo una riga di dettaglio scheda in base al numero di giorni previsto
                for (int i = 0; i < giorni; i++)
                {
                    dettaglioScheda.Data = inizio.AddDays(i);
                    dettaglioScheda.Giorno = i + 1;
                    dettaglioScheda.Scheda_Id = scheda.Scheda_Id;
                    db.DettaglioSchedas.Add(dettaglioScheda);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(scheda);
        }

        // GET: Schedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheda scheda = db.Schedas.Find(id);
            if (scheda == null)
            {
                return HttpNotFound();
            }
            return View(scheda);
        }

        // POST: Schedas/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Scheda_Id,Numero,NumeroG,DataI,DataF,Uid")] Scheda scheda)
        {
            if (ModelState.IsValid)
            {

                db.Entry(scheda).State = EntityState.Modified;
                db.SaveChanges();
                db.DettaglioSchedas.RemoveRange(db.DettaglioSchedas.Where(d=>d.Scheda_Id == scheda.Scheda_Id && d.Data > scheda.DataF));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheda);
        }

        // GET: Schedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheda scheda = db.Schedas.Find(id);
            if (scheda == null)
            {
                return HttpNotFound();
            }
            return View(scheda);
        }

        // POST: Schedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scheda scheda = db.Schedas.Find(id);
            db.Schedas.Remove(scheda);
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
