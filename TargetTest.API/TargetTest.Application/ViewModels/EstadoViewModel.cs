using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTest.Application.ViewModels
{
    public class EstadoViewModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public RegiaoViewModel Regiao { get; set; }
    }
}
