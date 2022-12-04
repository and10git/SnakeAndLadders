using API.Entidades;
using API.Entidades.Interfaces;
using API.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Servicios
{
    public class JugadorService : IJugadorService
    {
        private readonly IJugador _jugador;
        private readonly IDadoService _dadoService;
        public JugadorService(IJugador jugador, IDadoService dadoService)
        {
            this._jugador = jugador;
            _dadoService = dadoService;
        }

        public JugadorService() : this(new Jugador(string.Empty), new DadoService())
        {
        }

        public void MoverPosicion(Jugador jugador, int cantidadCasilleros)
        {
            if(jugador.Posicion + cantidadCasilleros <= Constantes.Constantes.TOTAL_CASILLEROS)
                jugador.Posicion += cantidadCasilleros;
        }

        public Jugador CrearJugador(string nombre)
        {
            return new Jugador(nombre);            
        }

        public bool EsGanador(Jugador jugador)
        {
            return jugador.Posicion >= Constantes.Constantes.TOTAL_CASILLEROS;
        }

        public int GetPosicion(Jugador jugador)
        {
           return jugador.Posicion;
        }

        public int LanzarDado()
        {
            return _dadoService.Lanzar();
        }

        public void SetPosicion(Jugador jugador, int posicion)
        {
            jugador.Posicion = posicion;
        }
    }
}
