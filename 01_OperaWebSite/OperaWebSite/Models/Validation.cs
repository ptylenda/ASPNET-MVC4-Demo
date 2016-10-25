using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperaWebSite.Models
{
    public class OperaYearAttribute : ValidationAttribute
    {
        public OperaYearAttribute()
        {
            this.ErrorMessage = "This is not a valid opera year";
        }

        public override bool IsValid(object value)
        {
            int year = (int)value;
            return year >= 1598
        }
    }
}