using API.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Servicios.Interfaces
{
    public interface IJugadorService
    {
        void MoverPosicion(Jugador jugador, int cantidadCasilleros);
        Jugador CrearJugador(string nombre);
        bool EsGanador(Jugador jugador);
        int GetPosicion(Jugador jugador);
        int LanzarDado();
        void SetPosicion(Jugador jugador1, int posicion);
    }
}
