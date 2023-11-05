using PruebaTecnicaEvoltis_JonathanAybar.Context;
using PruebaTecnicaEvoltis_JonathanAybar.Models;
using PruebaTecnicaEvoltis_JonathanAybar.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PruebaTecnicaEvoltis_JonathanAybar.Repositories.Implementaciones
{
    public class EmpleadoRepository : IEmpleadoRepository<Empleado>
    {
        private readonly EmpleadoDbContext _contexto;

        public EmpleadoRepository()
        {
            EmpleadoDbContext contexto = new EmpleadoDbContext();
            _contexto = contexto;
        }
        public EmpleadoRepository(EmpleadoDbContext contexto)
        {
            _contexto = contexto;
        }

        public Empleado ObtenerPorId(int id)
        {
            return _contexto.Empleados.Find(id);
        }

        public IEnumerable<Empleado> ObtenerPorNombre(string nombre)
        {
            string nombreBusqueda = nombre.ToLower(); 

            var listadoEmpleados = _contexto.Empleados.ToList();
            var listaFiltrada = listadoEmpleados.Where(e => e.Nombre.ToLower().Contains(nombreBusqueda)).ToList();

            return listaFiltrada;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _contexto.Empleados.ToList();
        }

        public void Agregar(Empleado entidad)
        {
            _contexto.Empleados.Add(entidad);
            _contexto.SaveChanges();
        }

        public void Actualizar(Empleado entidad)
        {
            _contexto.Entry(entidad).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Eliminar(Empleado entidad)
        {
            var empleado = _contexto.Empleados.Find(entidad.ID);
            if (empleado != null)
            {
                _contexto.Empleados.Remove(empleado);
                _contexto.SaveChanges();
            }
        }
    }
}