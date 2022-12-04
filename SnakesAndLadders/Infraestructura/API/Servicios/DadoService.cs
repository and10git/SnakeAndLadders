using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Servicios
{
    public class DadoService : IDadoService
    {
        public int Lanzar()
        {
            return new Random().Next(1, Constantes.Constantes.TOTAL_CARAS_DADO);
        }
    }
}
