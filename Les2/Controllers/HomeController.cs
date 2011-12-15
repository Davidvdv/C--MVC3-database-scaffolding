using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Les2.Models;

namespace Les2.Controllers
{ 
    public class HomeController : Controller
    {
        private Les2Context db = new Les2Context();

        //
        // GET: /Home/

        public ViewResult Index()
        {
            var games = db.Games.Include(g => g.Genre);
            return View(games.ToList());
        }

        //
        // GET: /Home/Details/5

        public ViewResult Details(int id)
        {
            Game game = db.Games.Find(id);
            return View(game);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
            return View();
        } 

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            return View(game);
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            Game game = db.Games.Find(id);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            return View(game);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            return View(game);
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            Game game = db.Games.Find(id);
            return View(game);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}