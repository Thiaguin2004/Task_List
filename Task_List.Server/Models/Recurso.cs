using System.ComponentModel.DataAnnotations;

namespace Task_List.Server.Models
{
    public class Recurso
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
    }
}
