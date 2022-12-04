using API.Entidades;
using API.Servicios;
using API.Servicios.Interfaces;
using Moq;
using static API.Enum.Enum;


namespace Test;

/// <summary>
// As a player
// I want to be able to move my token
// So that I can get closer to the goal
/// </summary>
public class US1
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
    /// Given the game is started
    /// When the token is placed on the board
    /// Then the token is on square 1
    /// </summary>
    [Test]
    public void Deberia_Inicializar_Posiciones_En_Uno()
    {
        List<Jugador> jugadores = CrearJugadores();
        _tableroService.Iniciar(jugadores);

        Assert.IsTrue(_tableroService.EstadoActual().Equals(EstadoJuego.INICIADO));
        Assert.IsFalse(jugadores.Any(x => x.Posicion != 1));
    }

    /// <summary>
    /// UAT 2
    /// Given the token is on square 1
    /// When the token is moved 3 spaces
    /// Then the token is on square 4
    /// </summary>
    [Test]
    public void Deberia_Mover_Tres_Casilleros_Y_Quedar_En_Posicion_Cuatro()
    {
        List<Jugador> jugadores = CrearJugadores();

        _tableroService.Iniciar(jugadores);
        _jugadorService.MoverPosicion(jugadores.First(), 3);

        Assert.IsTrue(_jugadorService.GetPosicion(jugadores.First()) == 4);
    }

    /// <summary>
    /// UAT 3
    /// Given the token is on square 1
    /// When the token is moved 3 spaces
    /// And then it is moved 4 spaces
    /// Then the token is on square 8
    /// </summary>
    [Test]
    public void Deberia_Quedar_Posicion_Ocho()
    {
        List<Jugador> jugadores = CrearJugadores();
        _tableroService.Iniciar(jugadores);

        _tableroService.Iniciar(jugadores);
        _jugadorService.MoverPosicion(jugadores.First(), 3);
        _jugadorService.MoverPosicion(jugadores.First(), 4);

        Assert.IsTrue(_jugadorService.GetPosicion(jugadores.First()) == 8);
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