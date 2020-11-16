using System.ComponentModel.DataAnnotations;

namespace Moradia.Data.Model
{
    public class Familia
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Id_Condominio { get; set; }
        public int Apto { get; set; }
    }
}
