using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Del1.Models;
using WebApp_Del1.DAL;
using System.Diagnostics.CodeAnalysis;
namespace WebApp_Del1.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {
        private readonly IBillettRepository _db;
        //private readonly BillettContext _db;
        private readonly ILogger<BillettController> _log;
        public BillettController(IBillettRepository db, ILogger<BillettController> log)
        {
            _db = db;
            _log = log;
        }
        
        [ExcludeFromCodeCoverage]
        public async Task<List<Havner>> HentAlleHavner_Fra()
        {
          //  List<Havner> lister = new List<Havner>();
          //  lister.Add(new Havner());

             //return await _db.HentAlleHavner_Fra(); 

            // return lister.ToList(); //ToListAsync
             return await _db.HentAlleHavner_Fra();
        }

        

        public async Task<ActionResult> LagreBillett(Billett lagetBillett)
        {
            
            if (ModelState.IsValid)
            {
                bool returOk = await _db.LagreBillett(lagetBillett);
                if (!returOk)
                {
                    _log.LogInformation("Feil i inputvalidering");
                    return BadRequest("Feil i inputvalidering på server");
                }
                return Ok("Billett lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");

        }

        public async Task<List<Billett>> HentBillett()
        {
            return await _db.HentBillett();
        }

        public async Task<List<ankomstHavner>> HentAlleHavnerTil(int id)
        {
            return await _db.HentAlleHavnerTil(id);
        }
    }
}