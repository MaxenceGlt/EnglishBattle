using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishBattle.Data;
using EnglishBattle.Data.Services;
using EnglishBattle.Models;

namespace EnglishBattle.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            // renvoie la vue
            return View();
        }

        public ActionResult Login()
        {
            // Récupération du hall of fame
            PartieService partieService = new PartieService(new EnglishBattleEntities());
            Dictionary<string, int> dictionary = partieService.GetTopPlayers();
            ViewBag.dictionary = dictionary;
            // renvoie la vue
            return View();
        }


        [HttpPost]
        public ActionResult Login(ConnexionViewModel model)
        {
            // vérification coté serveur que les données sont valides
            if (ModelState.IsValid)
            {
                // ici on vérifie si l'utilisateur est en base de données
                UtilisateurService utilisateurService = new UtilisateurService(new EnglishBattle.Data.EnglishBattleEntities());

                Joueur joueur = utilisateurService.GetItem(model.Email, model.Password);

                if (joueur != null)
                {
                    // ajoute l'utilisateur dans la session
                    Session["utilisateur"] = joueur;

                    // effectue un redirect avec l'url Home/Index
                    return RedirectToAction("Index", "Game");
                }
                else
                {
                    ViewBag.Error = "Email ou mot de passe invalide";
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            // vérification coté serveur que les données sont valides
            if (ModelState.IsValid)
            {
                EnglishBattleEntities context = new EnglishBattle.Data.EnglishBattleEntities();

                // ici on enregistre l'utilisateur en base de données
                UtilisateurService utilisateurService = new UtilisateurService(context);

                // créé un utilisateur
                Joueur joueur = new Joueur();

                joueur.nom = model.Nom;
                joueur.prenom = model.Prenom;
                joueur.email = model.Email;
                joueur.motDePasse = model.MotDePasse;
                joueur.idVille = 10;
                joueur.niveau = 1;
                //joueur.idVille = model.IdVille;
                //joueur.niveau = model.Niveau;

                utilisateurService.Insert(joueur);

                // effectue un redirect avec l'url Home/Index
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}