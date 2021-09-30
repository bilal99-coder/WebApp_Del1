using Microsoft.EntityFrameworkCore;
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

        //Henter ut alle Havner inn i første select (Reise fra)
        public async Task<List<Havn>> HentAlleStasjonerFra()
        {
            try
            {
                List<Havn> alleHavner = await _db.AlleHavner.ToListAsync();
                return alleHavner; 
              
            }
            catch
            {
                return null;
            }
        }


        public async Task<List<Havn>> HentAlleStasjonerTil (int id)
        {
            try
            {
                //Henter Havnen som kunden ønsket fra databasen 
                Havn ønksetHavn = await _db.AlleHavner.FirstOrDefaultAsync(havn => havn.HavnId == id);
                Ruter rute = await _db.Ruter.FirstOrDefaultAsync(rute => rute.avgangHavnen == ønksetHavn);
                List<Havn> alleMulige_AnkomstHavner = rute.ankomstHavner; 
                return alleMulige_AnkomstHavner;
            }
            catch
            {
                return null;  
            }
        }
    }
}
