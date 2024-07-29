using System.ComponentModel.DataAnnotations;

namespace Task_List.Server.Models
{
    public class TarefaRecursos
    {
        [Key]
        public int Id { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }
    }
}
