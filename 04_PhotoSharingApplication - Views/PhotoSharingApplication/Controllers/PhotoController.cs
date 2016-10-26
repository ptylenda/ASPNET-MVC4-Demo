using PhotoSharingApplication.Filters;
using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    [ControllerActionAudit]
    public class PhotoController : Controller
    {
        private readonly PhotoSharingContext context;

        public PhotoController(PhotoSharingContext context)
        {
            this.context = context;
        }

        //
        // GET: /Photo/
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
        
        [HttpGet]
        public ActionResult Display(int id)
        {
            var photos = this.context.Photos.Find(id);
            if (photos == null)
            {
                return this.HttpNotFound();
            }

            return this.View(photos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo { CreateDate = DateTime.Now };
            return this.View(photo);
        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreateDate = DateTime.Now;

            if (!this.ModelState.IsValid)
            {
                return this.View(photo);
            }

            photo.ImageMimeType = image.ContentType;
            photo.PhotoFile = new byte[image.ContentLength];
            image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);

            this.context.Photos.Add(photo);
            this.context.SaveChanges();

            return this.Redirect("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var photo = context.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Delete", photo);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileContentResult GetImage(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo != null)
            {
                return this.File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            var photos = context.Photos
                .OrderByDescending(x => x.CreateDate)
                .AsQueryable();

            if (number > 0)
            {
                photos = photos.Take(number);
            }

            return this.PartialView(photos.ToList());
        }
    }
}
