using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperaWebSite.Models
{
    public class Opera
    {
        public int OperaId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [OperaYear]
        [Required]
        public int Year { get; set; }

        public string Composer { get; set; }
    }
}