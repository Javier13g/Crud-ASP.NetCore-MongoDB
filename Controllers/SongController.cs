using crudSimple.Models;
using crudSimple.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Bson;
using System.Collections.Generic;

namespace crudSimple.Controllers
{
    public class SongController: Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        // GET: Album/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Song/Create
        public ActionResult Create(string id)
        {
            SongViewModel songVM = new SongViewModel() { AlbumId = id, Song = new Song() };
            return View(songVM);
        }

        // POST: Song/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = db.GetAlbumById(collection["AlbumId"]);
                if(album.Songs == null)
                album.Songs = new List<Song>();

                album.Songs.Add(new Song
                {
                    NameSong = collection["Song.NameSong"],
                    Duration = int.Parse(collection["Song.Duration"])
                });
                
                db.UpdateAlbum(album);
                return RedirectToAction("Index", "Album");
            }
            catch
            {
                return View();
            }
        }
    }
}