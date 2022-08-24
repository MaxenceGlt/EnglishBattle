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
    public class AccueilController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            // renvoie la vue
            return View();
        }


        [HttpPost]
        public ActionResult Index(ConnexionViewModel model)
        {
            // vérification coté serveur que les données sont valides
            if (ModelState.IsValid)
            {
                // ici on vérifie si l'utilisateur en base de données
                JoueurService joueurService = new JoueurService(new EnglishBattle.Data.EnglishBattleEntities());

                Joueur joueur = joueurService.GetItem(model.Email, model.Password);

                if (joueur != null)
                {
                    // ajoute l'utilisateur dans la session
                    Session["utilisateur"] = joueur;

                    // effectue un redirect avec l'url Home/Index
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Email ou mot de passe invalide";
                }
            }

            return View();
        }

        
    }
}