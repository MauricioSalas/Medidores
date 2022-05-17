using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public interface IMedidoresDAL
    {
        List<Medidor> ObtenerMedidores();
        void IngresarLectura(Medidor medidor);
        List<Medidor> ObtenerLecturas();
    }
}
