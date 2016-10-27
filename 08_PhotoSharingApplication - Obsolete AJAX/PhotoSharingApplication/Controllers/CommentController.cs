using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Controllers
{
    public class CommentController : Controller
    {
        private IPhotoSharingContext context;

        //Constructors
        public CommentController()
        {
            context = new PhotoSharingContext();
        }

        public CommentController(IPhotoSharingContext Context)
        {
            context = Context;
        }

        //
        // GET: /Comment/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Comment comment = context.FindCommentById(id);
            ViewBag.PhotoID = comment.PhotoID;
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = context.FindCommentById(id);
            context.Delete<Comment>(comment);
            context.SaveChanges();
            return RedirectToAction("Display", "Photo", new { id = comment.PhotoID });
        }

        public PartialViewResult _CreateComment(int photoId)
        {
            var comment = new Comment { PhotoID = photoId };
            this.ViewBag.PhotoID = photoId;
            return this.PartialView("_CreateComment", comment);
        }

        [ChildActionOnly]
        [HttpGet]
        public PartialViewResult _CommentsForPhoto(int photoId)
        {
            var comments = context.Comments.Where(x => x.PhotoID == photoId).ToList();
            this.ViewBag.PhotoID = photoId;
            return this.PartialView(comments);
        }

        [HttpPost]
        public PartialViewResult _CommentsForPhoto(Comment comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView("_CreateComment", comment);
            }

            this.context.Add<Comment>(comment);
            this.context.SaveChanges();
            return this._CommentsForPhoto(comment.PhotoID);
        }
    }
}
