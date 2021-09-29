using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1.DAL
{
    public class BillettRepository: IBillettRepository 
    {
        private BillettContext _db;
        public BillettRepository(BillettContext db)
        {
            _db = db; 
        }

        //Henter ut alle stasjoner inn i første select (stasjoner fra)
        public async Task<List<string>> HentAlleStasjonerFra()
        {
            try
            {
                // Returnerer Alle Avgangby kolonne i Ruter tabellen. --Ruter tabellen har to kolonner : AvgangBy og AnkomstBy
                List<string > alleByer =  _db.Ruter.Where( k => k.AvgangBy  !=  null ).Select( c => c.AvgangBy ).ToListAsync(); 
                return alleByer;
            }
            catch
            {
                return null;
            }
        }
    }
}
