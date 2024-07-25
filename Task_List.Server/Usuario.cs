using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_List.Server
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string funcao { get; set; }
    }
}
