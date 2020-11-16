using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moradia.Data.Model
{
    public class Morador
    {
        [Key]
        public int Id { get; set; }
        public int Id_Familia { get; set; }
        public string Nome { get; set; }
        public int QuantidadeBichosEstimacao { get; set; }
    }
}
