using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishBattle.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        
        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Le password doit comporter au moins {2} caractères.", MinimumLength = 6)]
        public string MotDePasse { get; set; }

        [Required]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        [Required]
        [Display(Name = "Niveau")]
        public int Niveau { get; set; }
    }
}