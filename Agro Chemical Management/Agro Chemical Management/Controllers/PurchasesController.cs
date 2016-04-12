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
    public class PurchasesController : Controller
    {
        private AgroChemicalDbEntities db = new AgroChemicalDbEntities();
        private const string PURCHASE_ITEMS_SESSION_KEY = "PurchaseItems";
        // GET: Purchases
        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Party);
            return View(purchases.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        
        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.PartyCode = new SelectList(db.Parties, "PartyCode", "Name");
            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name");
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseId", "InvoiceNumber");

            return View();
        }
        

        [HttpPost]
        public void CreatePurchaseItem(string ProductCode, string Quantity, string Price, string TaxAmount, string Total)
        {            
            PurchaseItem purchaseItem = new PurchaseItem() {
                ProductCode = Convert.ToInt32(ProductCode),
                Price = Convert.ToDecimal(Price),
                TaxAmount =Convert.ToDecimal(TaxAmount),
                Quantity = Convert.ToInt32(Quantity),
                Total=Convert.ToDecimal(Total)                
            };
            var purchaseItems = TempData[PURCHASE_ITEMS_SESSION_KEY] as List<PurchaseItem>;
            if(purchaseItems == null)
            {
                purchaseItems = new List<PurchaseItem>();                
            }
            purchaseItems.Add(purchaseItem);
            TempData[PURCHASE_ITEMS_SESSION_KEY] = purchaseItems;
        }
        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseId,InvoiceNumber,PurchaseDate,PartyCode,TotalPurchaseValue,BillType,Opertator")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                //TODO : possibly user transaction.                
                db.Purchases.Add(purchase);
                db.SaveChanges();
                var purchaseItems = TempData[PURCHASE_ITEMS_SESSION_KEY] as List<PurchaseItem>;
                if (purchaseItems != null)
                {
                    //Substitute this to all purchaseItems before sending to db
                    foreach (var item in purchaseItems)
                    {
                        item.PurchaseID = purchase.PurchaseId;
                        db.PurchaseItems.Add(item);
                        db.SaveChanges();
                    }                        
                }
                //clear the purchases items in TempData as they are now moved to db
                TempData[PURCHASE_ITEMS_SESSION_KEY] = null;
                return RedirectToAction("Index");
            }

            ViewBag.PartyCode = new SelectList(db.Parties, "PartyCode", "Name", purchase.PartyCode);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCode = new SelectList(db.Products, "ProductCode", "Name");
            ViewBag.PartyCode = new SelectList(db.Parties, "PartyCode", "Name", purchase.PartyCode);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseId,InvoiceNumber,PurchaseDate,PartyCode,TotalPurchaseValue,BillType,Opertator")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartyCode = new SelectList(db.Parties, "PartyCode", "Name", purchase.PartyCode);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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
