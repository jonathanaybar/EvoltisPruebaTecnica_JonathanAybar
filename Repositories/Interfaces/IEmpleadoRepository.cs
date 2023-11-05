using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaEvoltis_JonathanAybar.Repositories.Interfaces
{
    public interface IEmpleadoRepository<T> where T : class
    {
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerPorNombre(string nombre);
        IEnumerable<T> ObtenerTodos();
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
    }
}
