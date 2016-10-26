using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    internal class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {
            var photo1 = new Photo
            {
                Title = "Test photo 1",
                Description = "Hello there man",
                UserName = "Piotr",
                ImageMimeType = "image/jpeg",
                CreateDate = DateTime.Now,
                PhotoFile = this.getFileBytes(@"\Images\flower.jpg"),
            };

            var photo2 = new Photo
            {
                Title = "Test photo 2",
                Description = "Bye there man",
                UserName = "Piotr",
                ImageMimeType = "image/jpeg",
                CreateDate = DateTime.Now,
                PhotoFile = this.getFileBytes(@"\Images\flower.jpg"),
            };

            var comment1 = new Comment
            {
                Body = "Comment for photo no. 1",
                Photo = photo1,
                Subject = "Nice",
                UserName = "Master"
            };

            var comment2 = new Comment
            {
                Body = "Comment for photo no. 2",
                Photo = photo2,
                Subject = "Nice",
                UserName = "Master"
            };

            context.Photos.Add(photo1);
            context.Photos.Add(photo2);
            context.Comments.Add(comment1);
            context.Comments.Add(comment2);

            context.SaveChanges();
        } 

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}