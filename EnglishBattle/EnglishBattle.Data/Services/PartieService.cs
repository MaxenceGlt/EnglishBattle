using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class PartieService
    {
        private EnglishBattleEntities context;
        
        public PartieService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        public void Insert(Joueur joueur)
        {
            using (context)
            {
                context.Joueur.Add(joueur);
                context.SaveChanges();
            }
        }

        public void Insert(Partie partie)
        {
            using (context)
            {
                context.Partie.Add(partie);
                context.SaveChanges();
            }
        }

        public int topScore(int idJoueur)
        {
            using (context)
            {
                return (from p in context.Partie 
                            where p.idJoueur == idJoueur 
                            select (int?) p.score ).Max() ?? 0;
            }
        }

        public Dictionary<string, int> GetTopPlayers()
        {
            using (context)
            {
                var topPlayersArray = (from p in context.Partie
                            join j in context.Joueur on p.idJoueur equals j.id
                            orderby p.score descending
                            select new { Name = j.prenom, Score = (int?)p.score ?? 0 } ).Take(5).ToList();

                Dictionary<string, int> result = new Dictionary<string, int>();
                
                foreach (var element in topPlayersArray)
                {
                    if (result.ContainsKey(element.Name))
                    {
                        continue;
                    }
                    result.Add(element.Name, element.Score);
                }

                return result;
            }
        }
    }
}
