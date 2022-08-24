using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishBattle.Data.Services
{
    public class PartieViewModel
    {
        [Required]
        [Display(Name = "Participe passé")]
        [DataType(DataType.Text)]
        public string participePasse { get; set; }

        [Required]
        [Display(Name = "Preterit")]
        [DataType(DataType.Text)]
        public string preterit { get; set; }
    }
}