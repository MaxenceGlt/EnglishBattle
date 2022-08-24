using EnglishBattle.Data.Services;
using EnglishBattle.Data;
using EnglishBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishBattle.Objects;

namespace EnglishBattle.Controllers
{
    public class InscriptionController : Controller
    {
        //Get Register
        public ActionResult Index()
        {
            EnglishBattleEntities context = new EnglishBattle.Data.EnglishBattleEntities();

            VilleService villeService = new VilleService(context);
            ViewBag.libelleVilles = villeService.GetList();
            Niveau[] niveaux = { new Niveau(1, "débutant"), new Niveau(2, "intermédiaire"), new Niveau(3, "expert") };
            List<Niveau> listNiveaux = new List<Niveau>();
            listNiveaux.AddRange(niveaux);
            ViewBag.niveau = listNiveaux;
            // renvoie la vue
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterViewModel model)
        {
            // vérification coté serveur que les données sont valides
            if (ModelState.IsValid)
            {
                EnglishBattleEntities context = new EnglishBattle.Data.EnglishBattleEntities();

                // ici on enregistre l'utilisateur en base de données
                JoueurService joueurService = new JoueurService(context);
                VilleService villeService = new VilleService(context);

                // créé un utilisateur
                Joueur joueur = new Joueur();

                joueur.nom = model.Nom;
                joueur.prenom = model.Prenom;
                joueur.email = model.Email;
                joueur.motDePasse = model.MotDePasse;
                int idVille = villeService.GetIdOfVille(model.Ville);
                joueur.idVille = idVille;
                joueur.niveau = model.Niveau;

                joueurService.Insert(joueur);

                // effectue un redirect avec l'url Home/Index
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }

}