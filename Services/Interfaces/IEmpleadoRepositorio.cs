using PruebaTecnicaEvoltis_JonathanAybar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaEvoltis_JonathanAybar.Services.Interfaces
{
    interface IEmpleadoService
    {
        Empleado ObtenerEmpleadoPorId(int id);
        IEnumerable<Empleado> ObtenerEmpleadosPorNombre(string nombre);
        IEnumerable<Empleado> ObtenerTodosLosEmpleados();
        void AgregarEmpleado(Empleado empleado);
        void ActualizarEmpleado(Empleado empleado);
        void EliminarEmpleado(Empleado empleado);
    }
}
