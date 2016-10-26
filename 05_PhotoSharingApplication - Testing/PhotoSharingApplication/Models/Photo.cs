using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        [DisplayName("Added date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("User")]
        public string UserName { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}