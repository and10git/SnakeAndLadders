using API.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Enum.Enum;

namespace API.Servicios.Interfaces
{
    public interface ITableroService
    {
        bool CantidadJugadoresValida(string cantidadJugadores);
        EstadoJuego Iniciar(List<Jugador> jugadores);
        EstadoJuego Finalizar();
        EstadoJuego EstadoActual();
    }
}
