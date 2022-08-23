using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class ConnexionViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}