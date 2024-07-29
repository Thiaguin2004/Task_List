using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_List.Server.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public int? Telefone { get; set; }
        public ICollection<Projeto>? Projetos { get; set; }
    }
}
