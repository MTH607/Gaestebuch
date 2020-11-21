﻿namespace Gästebuch.Controllers
    {
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Gästebuch.Models;

    /// <summary>
    /// Defines the <see cref="EintragAdminController" />.
    /// </summary>
    public class EintragAdminController : Controller
        {
        /// <summary>
        /// Defines the db.
        /// </summary>
        private GästebuchEntities db = new GästebuchEntities();

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
            {
            return View(db.tbl_Einträge.ToList());
            }

        /// <summary>
        /// The Details.
        /// </summary>
        /// <param name="id">The id<see cref="Guid?"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Details(Guid? id)
            {
            if(id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            tbl_Einträge tbl_Einträge = db.tbl_Einträge.Find(id);
            if(tbl_Einträge == null)
                {
                return HttpNotFound();
                }
            return View(tbl_Einträge);
            }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
            {
            return View();
            }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="tbl_Einträge">The tbl_Einträge<see cref="tbl_Einträge"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rowguid,Nachname,Vorname,Bewertung,Verbesserungsvorschläge,Zeitpunkt,Autorisiert")] tbl_Einträge tbl_Einträge)
            {
            if(ModelState.IsValid)
                {
                tbl_Einträge.rowguid = Guid.NewGuid();
                db.tbl_Einträge.Add(tbl_Einträge);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(tbl_Einträge);
            }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="Guid?"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(Guid? id)
            {
            if(id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            tbl_Einträge tbl_Einträge = db.tbl_Einträge.Find(id);
            if(tbl_Einträge == null)
                {
                return HttpNotFound();
                }
            return View(tbl_Einträge);
            }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="tbl_Einträge">The tbl_Einträge<see cref="tbl_Einträge"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rowguid,Nachname,Vorname,Bewertung,Verbesserungsvorschläge,Zeitpunkt,Autorisiert")] tbl_Einträge tbl_Einträge)
            {
            if(ModelState.IsValid)
                {
                db.Entry(tbl_Einträge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(tbl_Einträge);
            }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="Guid?"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(Guid? id)
            {
            if(id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            tbl_Einträge tbl_Einträge = db.tbl_Einträge.Find(id);
            if(tbl_Einträge == null)
                {
                return HttpNotFound();
                }
            return View(tbl_Einträge);
            }

        /// <summary>
        /// The DeleteConfirmed.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
            {
            tbl_Einträge tbl_Einträge = db.tbl_Einträge.Find(id);
            db.tbl_Einträge.Remove(tbl_Einträge);
            db.SaveChanges();
            return RedirectToAction("Index");
            }

        /// <summary>
        /// The Dispose.
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/>.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing)
                {
                db.Dispose();
                }
            base.Dispose(disposing);
            }
        }
    }