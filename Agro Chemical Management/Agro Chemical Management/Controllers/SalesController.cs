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
    public class SalesController : Controller
    {
        private AgroChemicalDbEntities db = new AgroChemicalDbEntities();
        private const string SALE_ITEMS_SESSION_KEY = "SaleItems";

        // GET: Sales
        public ActionResult Index()
        {
            return View(db.Sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name");
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "CustomerName");
            return View();
        }

        [HttpPost]
        public void CreateSaleItem(string Price, string ProductCode, string Quantity,string TaxAmount,string Total)
        {
            SaleItem item = new SaleItem() {
                    Price=Convert.ToDecimal(Price),
                    ProductCode=Convert.ToInt32(ProductCode),
                    Quantity = Convert.ToInt32(Quantity),
                    TaxAmount=Convert.ToDecimal(TaxAmount),
                    Total=Convert.ToDecimal(Total)
            };
            var saleItems = TempData[SALE_ITEMS_SESSION_KEY] as List<SaleItem>;
            if (saleItems == null)
            {
                saleItems = new List<SaleItem>();
            }
            saleItems.Add(item);
            TempData[SALE_ITEMS_SESSION_KEY] = saleItems;
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleId,CustomerName,CustomerAddress,SaleDate,TotalSaleValue,SaleType,Operator")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                var saleItems = TempData[SALE_ITEMS_SESSION_KEY] as List<SaleItem>;
                if(saleItems != null)
                {
                    foreach(var item in saleItems)
                    {
                        item.SaleId = sale.SaleId;
                        db.SaleItems.Add(item);
                        db.SaveChanges();
                    }
                }
                //clear the sale items in TempData as they are now moved to db
                TempData[SALE_ITEMS_SESSION_KEY] = null;
                return RedirectToAction("Index");
            }

            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleId,CustomerName,CustomerAddress,SaleDate,TotalSaleValue,SaleType,Operator")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
