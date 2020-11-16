using System.ComponentModel.DataAnnotations;

namespace Moradia.Data.Model
{
    public class Condominio
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
    }
}
