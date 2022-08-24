using EnglishBattle.Data;
using EnglishBattle.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishBattle.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult index()
        {
            // Récupération de la variable de Session 
            Joueur joueur = (Joueur) Session["utilisateur"];

            // Création de l'objet service pour récupérer le meilleur score du joueur
            PartieService partieService = new PartieService(new EnglishBattleEntities());

            int topScore = partieService.topScore(joueur.id);

            ViewBag.JoueurInfo = "Utilisateur: " + joueur.prenom + ", meilleur score: " + 
                topScore + " verbes";

            // Récupération de la liste des verbes
            VerbeService verbeService = new VerbeService(new EnglishBattleEntities());
            List<Verbe> verbeList = verbeService.GetList();

            // Initialisation du compteur de question
            Session["nbQuestion"] = 1;
            ViewBag.compteur = 1;
            // Récupère une question aléatoire
            ViewBag.verbe = verbeList[new Random().Next(0, verbeList.Count)];
            Session["verbeList"] = verbeList;

            return View();
        }

        // GET  : Fin De Game
        public ActionResult end()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index(PartieViewModel model) {
            if (ModelState.IsValid) {
                // Vérifier si la réponse est juste 
                VerbeService verbeService = new VerbeService(new EnglishBattleEntities());
                PartieService partieService = new PartieService(new EnglishBattleEntities());
                Joueur joueur = (Joueur)Session["utilisateur"];

                Verbe verbe = verbeService.GetItem(model.participePasse, model.preterit);

                if ( verbe != null)
                {
                    // Passage à la question suivante
                    Session["nbQuestion"] = (int) Session["nbQuestion"] + 1;
                    ViewBag.compteur = (int) Session["nbQuestion"];
                    ViewBag.JoueurInfo = "Utilisateur: " + joueur.prenom + ", meilleur score: " +
                    partieService.topScore(joueur.id) + " verbes";
                    // Passage à la nouvelle question
                    List<Verbe> verbeList = (List<Verbe>)Session["verbeList"];
                    ViewBag.verbe = verbeList[new Random().Next(0, verbeList.Count)];
                }
                else
                {
                    // Enregistrement de la partie 
                    Partie partie = new Partie();
                    partie.idJoueur = joueur.id;
                    partie.score = (int) Session["nbQuestion"] == 1 ? 0 : (int)Session["nbQuestion"];
                    partieService.Insert(partie);
                    // Redirection page d'erreur
                    return RedirectToAction("End", "Game");
                }

            }
            return View();
        }
    }
}