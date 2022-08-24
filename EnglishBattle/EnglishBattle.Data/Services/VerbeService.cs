using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class VerbeService
    {
        private EnglishBattleEntities context;

        public VerbeService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        public List<Verbe> GetList()
        {
            using (context)
            {
                return context.Verbe.ToList();
            }
        }

        public Verbe GetItem(string participePasse, string preterit)
        {
            using (context)
            {
                IQueryable<Verbe> verbeToReturn = from verbe in context.Verbe
                                                  where verbe.participePasse == participePasse
                                                  && verbe.preterit == preterit
                                                  select verbe;

                return verbeToReturn.FirstOrDefault();
            }
        }
    }
}
