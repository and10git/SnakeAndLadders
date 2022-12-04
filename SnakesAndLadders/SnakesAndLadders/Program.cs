using API.Entidades;
using API.Servicios;
using System;
using static API.Enum.Enum;

internal class Program
{
    static void Main(string[] args)
    {
        #region variables
        TableroService tableroService = new TableroService();
        JugadorService jugadorService = new JugadorService();
        string inputNombreJugador = string.Empty;
        string inputCantJugadores = string.Empty;
        bool cantidadJugadoresValida = false;
        int cantidadJugadores = 0;
        var jugadores = new List<Jugador>();
        EstadoJuego estadoJuegoActual = EstadoJuego.NO_INICIADO;
        #endregion
        Console.WriteLine("*******************************************");
        Console.WriteLine("*** ¡¡BIENVENIDO A SNAKES AND LADDERS!! ***");
        Console.WriteLine("*******************************************");
        Console.WriteLine();
        Console.WriteLine("Primero configuraremos el juego...");

        #region Cantidad de jugadores
        while (!cantidadJugadoresValida)
        {
            Console.WriteLine();
            Console.Write("Por favor ingrese la cantidad de jugadores (2 o más): ");
            inputCantJugadores = Console.ReadLine();
            cantidadJugadoresValida = tableroService.CantidadJugadoresValida(inputCantJugadores);

            if (cantidadJugadoresValida)
                cantidadJugadores = int.Parse(inputCantJugadores);
        }
        #endregion

        #region Crear jugadores 
        for (int i = 1; i < cantidadJugadores + 1; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Por favor ingrese el nombre del jugador {i}: ");
            inputNombreJugador = Console.ReadLine();          

            while (string.IsNullOrWhiteSpace(inputNombreJugador))                
            {
                Console.WriteLine($"Debe ingresar un nombre para el jugador {i}: ");
                inputNombreJugador = Console.ReadLine();
            }
            var jugador = jugadorService.CrearJugador(inputNombreJugador);
            jugadores.Add(jugador);            
        }
        #endregion

        estadoJuegoActual = tableroService.Iniciar(jugadores);
        Console.WriteLine();
        Console.WriteLine("*******************");
        Console.WriteLine("*** ¡¡A JUGAR!! ***");
        Console.WriteLine("*******************");

        estadoJuegoActual = tableroService.Iniciar(jugadores);
        Console.WriteLine();
        Console.WriteLine($"¿Desea simular la partida? ([S] para confirmar)");

        bool simularPartida = Console.ReadLine().ToUpper().Equals("S");

        while (estadoJuegoActual != EstadoJuego.FINALIZADO)
        {
            if (simularPartida)
            {
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{jugador.Nombre} se encuentra en la posición {jugador.Posicion}");

                    Console.WriteLine($"Lanzamiento de dado...");
                    var posicionesAMover = jugadorService.LanzarDado();

                    Console.WriteLine($"Se moverá {posicionesAMover} posiciones");

                    jugadorService.MoverPosicion(jugador, posicionesAMover);

                    Console.WriteLine($"{jugador.Nombre} ahora se encuentra en la posición {jugador.Posicion}");

                    if (jugadorService.EsGanador(jugador))
                    {
                        estadoJuegoActual = tableroService.Finalizar();
                        Console.WriteLine("*******************************************");
                        Console.WriteLine($"*** ¡¡FELICITACIONES {jugador.Nombre} ES EL GANADOR!! ***");
                        Console.WriteLine("*******************************************");
                        break;
                    }
                }
            }
            else
            {
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{jugador.Nombre} se encuentra en la posición {jugador.Posicion}");
                                        
                    ConsoleKeyInfo readKey;
                    do
                    {
                        Console.WriteLine($"Presione [Enter] para lanzar el dado...");
                        readKey = Console.ReadKey(true);           
                    } while (readKey.Key != ConsoleKey.Enter);

                    var posicionesAMover = jugadorService.LanzarDado();

                    Console.WriteLine($"Se moverá {posicionesAMover} posiciones");

                    jugadorService.MoverPosicion(jugador, posicionesAMover);

                    Console.WriteLine($"{jugador.Nombre} ahora se encuentra en la posición {jugador.Posicion}");

                    if (jugadorService.EsGanador(jugador))
                    {
                        estadoJuegoActual = tableroService.Finalizar();
                        Console.WriteLine("*******************************************");
                        Console.WriteLine($"*** ¡¡FELICITACIONES {jugador.Nombre} ES EL GANADOR!! ***");
                        Console.WriteLine("*******************************************");
                        break;
                    }
                }
            }

        }
     
    }
}



