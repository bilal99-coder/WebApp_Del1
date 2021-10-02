using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Del1.Models;

namespace WebApp_Del1.DAL
{
    public interface IBillettRepository
    {
        // List<Havner> HentAlleHavner_Fra();
        // Task<bool> Bestill(Reiseinformasjon innReiseinformasjon, int[] lugar_Id, Person[] personerIBiletteten);
        Task<List<Havner>> HentAlleHavner_Fra();
        //Task<List<Havner>> HentAlleHavnerTil(int id);
       // double beregnPris(Reiseinformasjon info, Lugarer thisLugar);
       // double beregnLugarerPris();
       // double beregntjenesterPris();
        //Task velgLugar(int id);
       // Task<bool> fjernLugar(int id);
        }
}
