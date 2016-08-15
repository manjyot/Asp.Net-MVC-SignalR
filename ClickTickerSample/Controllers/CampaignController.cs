using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClickTickerSample;
using ClickTickerSample.Models;

namespace ClickTickerSample.Controllers
{
    public class CampaignController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult GetCampaign()
        {
            CampaignRepository _campaignRepository = new CampaignRepository();
            return PartialView("_CampaignList", _campaignRepository.GetAllDevTest());
        }

        // GET: Campaign
        public async Task<ActionResult> Index()
        {
            return View(await db.DevTests.ToListAsync());
        }

        private ActionResult View(List<DevTest> list, IEnumerable<DevTest> enumerable)
        {
            throw new NotImplementedException();
        }

        // GET: Campaign/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTest devTest = await db.DevTests.FindAsync(id);
            if (devTest == null)
            {
                return HttpNotFound();
            }
            return View(devTest);
        }

        // GET: Campaign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CampaignName,Date,Clicks,Conversions,Impressions,AffiliateName")] DevTest devTest)
        {
            if (ModelState.IsValid)
            {
                db.DevTests.Add(devTest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(devTest);
        }

        // GET: Campaign/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTest devTest = await db.DevTests.FindAsync(id);
            if (devTest == null)
            {
                return HttpNotFound();
            }
            return View(devTest);
        }

        // POST: Campaign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CampaignName,Date,Clicks,Conversions,Impressions,AffiliateName")] DevTest devTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devTest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(devTest);
        }

        // GET: Campaign/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTest devTest = await db.DevTests.FindAsync(id);
            if (devTest == null)
            {
                return HttpNotFound();
            }
            return View(devTest);
        }

        // POST: Campaign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DevTest devTest = await db.DevTests.FindAsync(id);
            db.DevTests.Remove(devTest);
            await db.SaveChangesAsync();
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
