using System.ComponentModel.DataAnnotations;

namespace Task_List.Server.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Recurso> Recursos { get; set; }
    }
}
