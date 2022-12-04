using API.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Enum.Enum;

namespace API.Entidades
{
    public class Tablero : ITablero
    {       
        public EstadoJuego Estado { get; set; }

    }
}
