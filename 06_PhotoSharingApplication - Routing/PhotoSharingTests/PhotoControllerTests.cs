using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoSharingApplication.Controllers;
using PhotoSharingApplication.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using PhotoSharingTests.Doubles;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void TestIndexReturnView()
        {
            var context = CreateContextEmpty();
            var controller = CreateController(context);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        [TestMethod]
        public void TestPhotoGalleryModelType()
        {
            var context = CreateContextWithPhotos();
            var controller = CreateController(context);

            var result = controller._PhotoGallery();

            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
            var viewResult = result as PartialViewResult;
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<Photo>));
        }
        
        [TestMethod]
        public void TestGetImageReturnType()
        {
            var context = CreateContextWithPhotos();
            var controller = CreateController(context);

            var result = controller.GetImage(context.Photos.First().PhotoId);

            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }

        [TestMethod]
        public void TestGetImageReturnProperImage()
        {
            var context = CreateContextWithPhotos();
            var controller = CreateController(context);

            var photo = context.Photos.Last();
            var result = controller.GetImage(photo.PhotoId);

            Assert.AreEqual(photo.ImageMimeType, result.ContentType);
            CollectionAssert.AreEqual(photo.PhotoFile, result.FileContents);
        }

        [TestMethod]
        public void TestPhotoGalleryNoParameter()
        {
            var context = CreateContextWithPhotos();
            var controller = CreateController(context);

            var expectedCount = context.Photos.Count();
            var result = controller._PhotoGallery() as PartialViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(List<Photo>));
            Assert.AreEqual(expectedCount, ((List<Photo>)result.Model).Count);
        }

        [TestMethod]
        public void TestPhotoGalleryIntParameter()
        {
            var context = CreateContextWithPhotos();
            var controller = CreateController(context);

            var expectedCount = 2;
            var result = controller._PhotoGallery(number: expectedCount) as PartialViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(List<Photo>));
            Assert.AreEqual(expectedCount, ((List<Photo>)result.Model).Count);
        }

        private static PhotoController CreateController(IPhotoSharingContext dataContext)
        {
            return new PhotoController(dataContext);
        }

        private static IPhotoSharingContext CreateContextEmpty()
        {
            return new FakePhotoSharingContext();
        }
        
        private static IPhotoSharingContext CreateContextWithPhotos()
        {
            var context = new FakePhotoSharingContext();
            context.Photos = new List<Photo> 
                        {
                            new Photo { PhotoId = 1, Description = "Test1", ImageMimeType = "image/jpeg", Title = "Title1", PhotoFile = new byte[] { 1 } },
                            new Photo { PhotoId = 2, Description = "Test2", ImageMimeType = "image/jpeg", Title = "Title2", PhotoFile = new byte[] { 2 } },
                            new Photo { PhotoId = 3, Description = "Test3", ImageMimeType = "image/jpeg", Title = "Title3", PhotoFile = new byte[] { 3 } },
                            new Photo { PhotoId = 4, Description = "Test4", ImageMimeType = "image/jpeg", Title = "Title4", PhotoFile = new byte[] { 4 } },
                            new Photo { PhotoId = 5, Description = "Test5", ImageMimeType = "image/jpeg", Title = "Title5", PhotoFile = new byte[] { 5 } },
                        }.AsQueryable();

            return context;
        }
    }
}
