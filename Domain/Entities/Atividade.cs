using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Speedfit.Domain.Entities
{
    public class Atividade : ClasseBasica
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Repeticoes { get; set; }
        public int TreinoId { get; set; }
    }
}
