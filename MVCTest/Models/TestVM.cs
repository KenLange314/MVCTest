using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
{
    public class Test1VM
    {
        [Required]
        [Display(Name="Test1 Name")]
        public string Name { get; set; }

        [StringLength(6,MinimumLength=6)]
        public string Phone { get; set; }

        public SelectListVM FavoriteColor { get; set; }

        public TriState? Married { get; set; }
    }

    public enum TriState
    {
        Yes,
        No,
        Maybe
    }

    public class Test2VM
    {
        [Required]
        [Display(Name = "Test2 Name")]
        public string Name { get; set; }

        public string Horse { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

}