using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ginasio.Models
{
    public class Aulas
    {
        public Aulas()
        {
            ListaPraticantes = new HashSet<Usuarios>();
        }

        /// <summary>
        /// Id da aula
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nome da aula
        /// </summary>
        [StringLength(20)]
        public string Nome { get; set; }

        /// <summary>
        /// Breve descrição sobre a aula
        /// </summary>
        [StringLength(100)]
        public string Descricao { get; set; }

        /// <summary>
        /// Horário de início da aula
        /// </summary>

        [RegularExpression(@"^\d{2}:\d{2}$", ErrorMessage = "O horário deve estar no formato HH:mm")]
        public string Horario { get; set; }

        /// <summary>
        /// Duração da aula
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "A duração tem de ser um valor inteiro positivo")]
        public int Duracao { get; set; }

        /// <summary>
        /// Capacidade máxima de participantes da aula
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade tem de ser um valor inteiro positivo")]
        public int Capacidade { get; set; }

        /// <summary>
        /// Chave forasteira(FK) fazendo referência ao instrutor que leciona a aula
        /// </summary>
        [ForeignKey(nameof(Instrutor))]
        public int InstrutorFK { get; set; }
        public Instrutores Instrutor { get; set; }

        /// <summary>
        /// Lista de praticantes referentes a uma aula
        /// </summary>
        public ICollection<Usuarios> ListaPraticantes { get; set; }

    }
}
