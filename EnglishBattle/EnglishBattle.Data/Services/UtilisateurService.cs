using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace EnglishBattle.Data.Services
{
    public class UtilisateurService
    {
        private EnglishBattleEntities context;

        public UtilisateurService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Retourne un objet métier
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>objet métier</returns>
        public Joueur GetItem(int id)
        {
            using (context)
            {
                return context.Joueur.Find(id);
            }
        }

        public Joueur GetItem(string email, string password)
        {
            using (context)
            {
                IQueryable<Joueur> utilisateurs = from joueur in context.Joueur
                                                       where joueur.email == email
                                                       && joueur.motDePasse == password
                                                       select joueur;

                return utilisateurs.FirstOrDefault();
            }
        }

        /// <summary>
        /// Retourne un objet metier
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>objet metier</returns>
        public int CountUserByEmail(string email)
        {
            using (context)
            {
                IQueryable<Joueur> aUser = from joueur in context.Joueur
                                                where joueur.email == email
                                                select joueur;
                return aUser.Count();
            }
        }

        public List<Joueur> GetList()
        {
            using (context)
            {
                return context.Joueur.ToList();

            }
        }

        public void Insert(Joueur joueur)
        {
            using (context)
            {
                context.Joueur.Add(joueur);
                context.SaveChanges();
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
