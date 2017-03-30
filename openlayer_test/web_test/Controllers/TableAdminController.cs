using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;
using Openlayer_test.TESTDB.EF;
using web_test.Models;

namespace web_test.Controllers
{
    public class TableAdminController : Controller
    {
        private ITable1Repository _db = new Table1Repository();

        //
        // GET: /TableAdmin/

        public ActionResult Index()
        {
            var table1 = _db.GetAll();
            return View(table1.ToList());
        }

        //
        // GET: /TableAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            var table1 = _db.GetOne(id);
            if (table1 == null)
            {
                return HttpNotFound();
            }
            return View(table1);
        }

        //
        // GET: /TableAdmin/Create

        public ActionResult Create()
        {
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName");
            return View();
        }

        //
        // POST: /TableAdmin/Create

        [HttpPost]
        public ActionResult Create(Openlayer_test.TESTDB.Table1 table1)
        {
            if (ModelState.IsValid)
            {
                _db.Create(table1);
                return RedirectToAction("Index");
            }
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName", table1.VillageID);
            return View(table1);
        }

        //
        // GET: /TableAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var table1 = _db.GetOne(id);
            if (table1 == null)
            {
                return HttpNotFound();
            }
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName", table1.VillageID);
            return View(table1);
        }

        //
        // POST: /TableAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(Openlayer_test.TESTDB.Table1 table1)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(table1).State = EntityState.Modified;
                _db.Update(table1);
                return RedirectToAction("Index");
            }
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName", table1.VillageID);
            return View(table1);
        }

        //
        // GET: /TableAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var table1 = _db.GetOne(id);
            if (table1 == null)
            {
                return HttpNotFound();
            }
            return View(table1);
        }

        //
        // POST: /TableAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {   
            _db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}