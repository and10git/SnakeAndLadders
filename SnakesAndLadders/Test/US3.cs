using API.Constantes;
using API.Entidades;
using API.Servicios;
using API.Servicios.Interfaces;
using Moq;

namespace Test;

/// <summary>
/// As a player
/// I want to move my token based on the roll of a die
/// So that there is an element of chance in the game
/// </summary>
public class US3
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
    /// UAT1
    /// Given the game is started
    /// When the player rolls a die
    /// Then the result should be between 1-6 inclusive
    /// </summary>
    [Test]
    public void Deberia_Devolver_Valor_Entre_Uno_Y_Seis()
    {
        _tableroService.Iniciar(CrearJugadores());
        bool resultadoLanzamientoValido = false;
        bool resultadoLanzamientoInValido = true;

        for(var i = 0; i < Constantes.TOTAL_CASILLEROS; i++)
        {
            var resultadoLanzamiento = _jugadorService.LanzarDado();
            resultadoLanzamientoValido = resultadoLanzamiento >= 1 && resultadoLanzamiento <= Constantes.TOTAL_CARAS_DADO;
            resultadoLanzamientoInValido = resultadoLanzamiento < 1 || resultadoLanzamiento > Constantes.TOTAL_CARAS_DADO;
        }
       
        Assert.IsTrue(resultadoLanzamientoValido);
        Assert.IsFalse(resultadoLanzamientoInValido);
    }

    /// <summary>
    /// UAT 2
    /// Given the player rolls a 4
    /// When they move their token
    /// Then the token should move 4 spaces
    /// </summary>
    [Test]
    public void Deberia_Moverse_Cuatro_Casilleros()
    {
        List<Jugador> jugadores = CrearJugadores();       

        var mockJugadorService = new Mock<IJugadorService>();
        mockJugadorService.Setup(x => x.LanzarDado()).Returns(4);        

        _jugadorService.SetPosicion(jugadores.First(), new Random().Next(1, Constantes.TOTAL_CASILLEROS - Constantes.TOTAL_CARAS_DADO));

        var posicionInicial = _jugadorService.GetPosicion(jugadores.First());

        var resultadoLanzamiento = mockJugadorService.Object.LanzarDado();
        _jugadorService.MoverPosicion(jugadores.First(), resultadoLanzamiento);

        var posicionFinal = _jugadorService.GetPosicion(jugadores.First());

        Assert.IsTrue(posicionFinal - posicionInicial == 4);
    }

    private List<Jugador> CrearJugadores() {
        List<Jugador> jugadores = new List<Jugador>();
        var jugador1 = _jugadorService.CrearJugador("Jugador1");
        var jugador2 = _jugadorService.CrearJugador("Jugador2");
        jugadores.Add(jugador1);
        jugadores.Add(jugador2);
        return jugadores;
    }

}