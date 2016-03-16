using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agro_Chemical_Management.Models;

namespace Agro_Chemical_Management.Controllers
{
    public class PurchaseItemsController : Controller
    {
        private AgroChemicalDbEntities db = new AgroChemicalDbEntities();

        // GET: PurchaseItems
        public ActionResult Index()
        {
            var purchaseItems = db.PurchaseItems.Include(p => p.Product).Include(p => p.Purchase);
            return View(purchaseItems.ToList());
        }

        // GET: PurchaseItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            if (purchaseItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name");
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseId", "InvoiceNumber");
            return View();
        }

        // POST: PurchaseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PurchaseID,ProductCode,Quantity,Price,TaxAmount,Total")] PurchaseItem purchaseItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseItems.Add(purchaseItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name", purchaseItem.ProductCode);
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseId", "InvoiceNumber", purchaseItem.PurchaseID);
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            if (purchaseItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name", purchaseItem.ProductCode);
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseId", "InvoiceNumber", purchaseItem.PurchaseID);
            return View(purchaseItem);
        }

        // POST: PurchaseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PurchaseID,ProductCode,Quantity,Price,TaxAmount,Total")] PurchaseItem purchaseItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name", purchaseItem.ProductCode);
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseId", "InvoiceNumber", purchaseItem.PurchaseID);
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            if (purchaseItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseItem);
        }

        // POST: PurchaseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            db.PurchaseItems.Remove(purchaseItem);
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
