using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_List.Server.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
