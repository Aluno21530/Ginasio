using System.ComponentModel.DataAnnotations.Schema;

namespace Ginasio.Models
{
    public class Treinamentos
    {
        public Treinamentos()
        {
            ListaPraticantes = new HashSet<Praticantes>();
        }

        /// <summary>
        /// Id do treinamento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do treinamento
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Breve desxrição do treinamento
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data de início do treinamento
        /// </summary>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data de término do treinamento
        /// </summary>
        public DateTime DataTermino { get; set; }

        /// <summary>
        /// Chave forasteira(FK) referente ao instrutor ao qual pertence o treinamento
        /// </summary>
        [ForeignKey(nameof(Instrutor))]
        public int InstrutorFK { get; set; }
        public Instrutores Instrutor { get; set; }

        /// <summary>
        /// Lista de praticantes que participam do treinamento
        /// </summary>
        public ICollection<Praticantes> ListaPraticantes { get; set; }
    }
}
