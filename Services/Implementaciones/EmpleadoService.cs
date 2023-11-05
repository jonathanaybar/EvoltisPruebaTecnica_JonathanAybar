using PruebaTecnicaEvoltis_JonathanAybar.Models;
using PruebaTecnicaEvoltis_JonathanAybar.Repositories.Implementaciones;
using PruebaTecnicaEvoltis_JonathanAybar.Repositories.Interfaces;
using PruebaTecnicaEvoltis_JonathanAybar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PruebaTecnicaEvoltis_JonathanAybar.Services.Implementaciones
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository<Empleado> _repositorio;

        public EmpleadoService()
        {
            IEmpleadoRepository<Empleado> repositorio = new EmpleadoRepository();
            _repositorio = repositorio;
        }
        public EmpleadoService(IEmpleadoRepository<Empleado> repositorio)
        {
            _repositorio = repositorio;
        }

        public Empleado ObtenerEmpleadoPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }
        public IEnumerable<Empleado> ObtenerEmpleadosPorNombre(string nombre)
        {
            return _repositorio.ObtenerPorNombre(nombre);
        }

        public IEnumerable<Empleado> ObtenerTodosLosEmpleados()
        {
            return _repositorio.ObtenerTodos();
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            _repositorio.Agregar(empleado);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            _repositorio.Actualizar(empleado);
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            _repositorio.Eliminar(empleado);
        }
    }
}