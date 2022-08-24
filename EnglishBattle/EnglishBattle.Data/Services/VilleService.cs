using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class VilleService
    {
        private EnglishBattleEntities context;

        public VilleService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Retourne un objet métier
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>objet métier</returns>
        public Ville GetItem(int id)
        {
            using (context)
            {
                return context.Ville.Find(id);
            }
        }

        public List<String> GetLibelleVille()
        {
            using (context)
            {
                IQueryable<String> nomVilles = (from ville in context.Ville select ville.nom);

                return nomVilles.ToList();
            }
        }

        public int GetIdOfVille(String libelleVille)
        {
            using (context)
            {
                IQueryable<int> idVille = from ville in context.Ville
                                                  where ville.nom == libelleVille
                                                  select ville.id;
                return idVille.Count();
            }
        }


        public List<Ville> GetList()
        {
            using (context)
            {
                return context.Ville.ToList();

            }
        }

        public void Update(Joueur joueur)
        {
            using (context)
            {
                context.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Joueur joueur)
        {
            using (context)
            {
                context.Entry(joueur).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
