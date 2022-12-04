using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Enum.Enum;

namespace API.Entidades.Interfaces
{
    public interface ITablero
    {
        EstadoJuego Estado { get; set; }
    }
}
