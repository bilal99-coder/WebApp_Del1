using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1.DAL
{
    public interface IBillettRepository
    {
        Task<List<Havn>> HentAlleStasjonerFra();
    }
}
