using API.Entidades;
using API.Entidades.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Enum.Enum;

namespace API.Servicios
{
    public class TableroService : ITableroService
    {
        private readonly ITablero _tablero;

        public TableroService(ITablero tablero)
        {      
            this._tablero = tablero;
        }

        public TableroService() : this(new Tablero())
        {
        }

        public EstadoJuego Iniciar(List<Jugador> jugadores)
        {
            foreach (var jugador in jugadores)
                jugador.Posicion = 1;

            _tablero.Estado = EstadoJuego.INICIADO;
            return _tablero.Estado;
        }

        public bool CantidadJugadoresValida(string inputCantJugadores)
        {
            int cantJugadoresValue = 0;
            var inputValido = int.TryParse(inputCantJugadores, out cantJugadoresValue);
            return inputValido && cantJugadoresValue > 1;
        }

        public EstadoJuego EstadoActual()
        {
            return _tablero.Estado;
        }

        public EstadoJuego Finalizar()
        {
            _tablero.Estado = EstadoJuego.FINALIZADO;

            return _tablero.Estado;
        }
    }
}
