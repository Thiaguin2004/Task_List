using System.ComponentModel.DataAnnotations;

namespace Task_List.Server.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Projeto> Projeto { get; set; }
        public ICollection<Tarefa> Tarefa { get; set; }
    }
}
