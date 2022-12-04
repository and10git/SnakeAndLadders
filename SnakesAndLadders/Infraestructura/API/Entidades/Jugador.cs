using API.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entidades
{
    public class Jugador : IJugador
    {
        private Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Posicion { get; set; }

        public Jugador(string nombre)
        {
            this.Id = Guid.NewGuid();
            this.Nombre = nombre;
            this.Posicion = 0;
        }
    }
}
