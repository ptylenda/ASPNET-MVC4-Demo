using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    internal class PhotoSharingContext : DbContext, IPhotoSharingContext
    {
        public PhotoSharingContext()
            : base("name=PhotoSharingContext")
        {
        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Comment> Comments { get; set; }

        IQueryable<Comment> IPhotoSharingContext.Comments
        {
            get { return this.Comments; }
        }

        IQueryable<Photo> IPhotoSharingContext.Photos
        {
            get { return this.Photos; }
        }

        public T Add<T>(T entity) where T : class
        {
            return this.Set<T>().Add(entity);
        }
        
        public T Delete<T>(T entity) where T : class
        {
            return this.Set<T>().Remove(entity);
        }

        public Photo FindPhotoById(int id)
        {
            return this.Set<Photo>().Find(id);
        }

        public Comment FindCommentById(int id)
        {
            return this.Set<Comment>().Find(id);
        }

        public Photo FindPhotoByTitle(string title)
        {
            return this.Set<Photo>().FirstOrDefault(x => x.Title == title);
        }
    }
}