using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaVentanas
{
    class Controller
    {
        private Model _m;
        public Controller()
        {
            _m = new Model();
        }

        public List<EmpresasEsquema> Buscar(string empresa)
        {
            return _m.Buscar(empresa);
        }

        public List<EmpresasEsquema> GetEmpresas()
        {
            return _m.GetEmpresas();
        }

        
    }
}
