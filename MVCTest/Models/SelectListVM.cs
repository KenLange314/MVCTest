using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Models
{
    public class SelectListVM
    {
        public string SelectedID { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}