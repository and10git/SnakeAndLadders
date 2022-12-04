using API.Constantes;
using API.Entidades;
using API.Servicios;
using API.Servicios.Interfaces;
using Moq;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Configuration;
using System.Numerics;
using System.Runtime.InteropServices;
using static API.Enum.Enum;

namespace Test;

/// <summary>
// As a player
// As a player
// I want to be able to win the game
// So that I can gloat to everyone around
/// </summary>
public class US2
{
    private IJugadorService _jugadorService;
    private ITableroService _tableroService;

    [OneTimeSetUp]
    public void Setup()
    {
        _jugadorService = new Mock<JugadorService>().Object;
        _tableroService = new Mock<TableroService>().Object;
    }

    /// <summary>
    /// UAT 1
    /// Given the token is on square 97
    /// When the token is moved 3 spaces
    /// Then the token is on square 100
    /// And the player has won the game
    /// </summary>
    [Test]
    public void Deberia_Setear_Posicion_Final_Y_Ganar_Partida()
    {
        List<Jugador> jugadores = CrearJugadores();

        _tableroService.Iniciar(jugadores);
        _jugadorService.SetPosicion(jugadores.First(), 97); 
        _jugadorService.MoverPosicion(jugadores.First(), 3);
        
        Assert.IsTrue(_jugadorService.GetPosicion(jugadores.First()) == Constantes.TOTAL_CASILLEROS);
        Assert.IsTrue(_jugadorService.EsGanador(jugadores.First()));
    }

    /// <summary>
    /// UAT 2
    /// Given the token is on square 97
    /// When the token is moved 4 spaces
    /// Then the token is on square 97
    /// And the player has not won the game
    /// </summary>
    [Test]
    public void Deberia_Mantener_Posicion_Si_Pasa_Cien()
    {
        List<Jugador> jugadores = CrearJugadores();

        _jugadorService.SetPosicion(jugadores.First(), 97);
        _jugadorService.MoverPosicion(jugadores.First(), 4);

        Assert.IsTrue(_jugadorService.GetPosicion(jugadores.First()) == 97);
        Assert.IsTrue(!_jugadorService.EsGanador(jugadores.First()));
    }

    private List<Jugador> CrearJugadores()
    {
        List<Jugador> jugadores = new List<Jugador>();
        var jugador1 = _jugadorService.CrearJugador("Jugador1");
        var jugador2 = _jugadorService.CrearJugador("Jugador2");
        jugadores.Add(jugador1);
        jugadores.Add(jugador2);
        return jugadores;
    }
}