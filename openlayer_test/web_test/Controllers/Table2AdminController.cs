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
using System.IO;

namespace web_test.Controllers
{
    public class Table2AdminController : Controller
    {
        private ITable2Repository _db = new Table2Repository();

        //
        // GET: /Table2Admin/

        public ActionResult Index()
        {
            var table2 = _db.GetAll();
            return View(table2.ToList());
        }

        //
        // GET: /Table2Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            var table2 = _db.GetOne(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            return View(table2);
        }

        //
        // GET: /Table2Admin/Create

        public ActionResult Create()
        {
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName");
            return View();
        }

        //
        // POST: /Table2Admin/Create

        [HttpPost]
        public ActionResult Create(Openlayer_test.TESTDB.Table2 table2)
        {
            if (ModelState.IsValid)
            {
                _db.Create(table2);
                return RedirectToAction("Index");
            }
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName", table2.VillageID);
            return View(table2);
        }

        //
        // GET: /Table2Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var table2 = _db.GetOne(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName", table2.VillageID);
            return View(table2);
        }

        //
        // POST: /Table2Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Openlayer_test.TESTDB.Table2 table2)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(table2).State = EntityState.Modified;
                _db.Update(table2);
                return RedirectToAction("Index");
            }
            var village_model = new VillageRepository();
            ViewBag.VillageID = new SelectList(village_model.GetAll(null), "VillageID", "VillageName", table2.VillageID);
            return View(table2);
        }

        //
        // GET: /Table2Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var table2 = _db.GetOne(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            return View(table2);
        }

        //
        // POST: /Table2Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Download(int id = 0)
        {
            var table2 = _db.GetOne(id);
            if (table2 == null)
            {
                return HttpNotFound();
            }
            string file_path = table2.RawFile.Replace(@"H:\RAW\RSImage\UAV\Ortho\", "~/Archive/RAW/");
            file_path = Server.MapPath(file_path.Replace("\\", "/"));
            string filename = System.IO.Path.GetFileName(file_path);
            System.IO.Stream iStream = new System.IO.FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.Read);

            return File(iStream, "image/tif", filename);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}