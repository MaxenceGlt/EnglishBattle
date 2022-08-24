using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishBattle.Objects
{
    public class Niveau
    {
        public int Id { get; set; }
        public string Nom{get; set; }
        public Niveau (int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }
    }
}