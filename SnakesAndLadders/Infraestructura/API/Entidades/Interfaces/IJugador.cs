using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entidades.Interfaces
{
    public interface IJugador
    {
        string Nombre { get; set; }
        int Posicion { get; set; }
    }
}
