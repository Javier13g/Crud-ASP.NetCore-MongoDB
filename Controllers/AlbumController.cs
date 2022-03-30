using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudSimple.Models;
using crudSimple.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace crudSimple.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        // GET: Album
        public ActionResult Index()
        {
            var albums = db.GetAllAlbums();
            return View(albums);
        }

        // GET: Album/Details/5
        public ActionResult Details(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View(); 
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var album = new Album()
                {
                    Name = collection["Name"],
                    AlbumImage = collection["AlbumImage"],
                    Artist = collection["Artist"],
                    Genre = collection["Genre"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"]),
                    Duration = int.Parse(collection["Duration"])
                };
                
                db.InsertAlbum(album);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // POST: Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var album = new Album()
                {
                    Id = new ObjectId(id),
                    Name = collection["Name"],
                    AlbumImage = collection["AlbumImage"],
                    Artist = collection["Artist"],
                    Genre = collection["Genre"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"]),
                    Duration = int.Parse(collection["Duration"])
                };

                db.UpdateAlbum(album);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.DeleteAlbum(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
