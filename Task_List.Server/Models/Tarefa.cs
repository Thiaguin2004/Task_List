using System.ComponentModel.DataAnnotations;

namespace Task_List.Server.Models
{
    public class Tarefa
    {
        [Key] 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public DateTime? DataRealInicio { get; set; }
        public DateTime? DataRealFim { get; set; }
        public int DuracaoHoras { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int? AntecessoraId { get; set; }
        public Tarefa Antecessora { get; set; }
        public ICollection<TarefaRecursos> TarefaRecursos { get; set; }

    }
}
