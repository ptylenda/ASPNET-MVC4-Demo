using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Filters;

namespace PhotoSharingApplication
{
    public class PhotoController : ApiController
    {
        private readonly IPhotoSharingContext context;

        public PhotoController(IPhotoSharingContext context)
        {
            this.context = context;
        }

        // GET api/<controller>
        public IEnumerable<Photo> Get()
        {
            return this.context.Photos;
        }

        // GET api/<controller>/5
        public Photo Get(int id)
        {
            var photo = this.context.FindPhotoById(id);
            if (photo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return photo;
        }

        public Photo Get(string title)
        {
            var photo = this.context.FindPhotoByTitle(title);
            if (photo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return photo;
        }

        // POST api/<controller>
        [ValidationActionFilter]
        public HttpResponseMessage Post(Photo photo)
        {
            this.context.Add<Photo>(photo);
            this.context.SaveChanges();

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, Url.Route(null, new { id = photo.PhotoID }));

            return response;
        }
        
        // PUT api/<controller>/5
        [ValidationActionFilter]
        public HttpResponseMessage Put(int id, Photo photo)
        {
            throw new Exception();
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var photo = this.context.FindPhotoById(id);
            if (photo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this.context.Delete<Photo>(photo);
            this.context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}