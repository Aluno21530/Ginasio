using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        /// Id do treino
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do treino
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O nome do treino deve conter apenas letras.")]
        public string Nome { get; set; }

        /// <summary>
        /// Breve descrição do treino
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Descricao { get; set; }

        /// <summary>
        /// Data de início do treino
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de inicio")]
        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]
        public string DataInicio { get; set; }

        /// <summary>
        /// Data de término do treino
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de fim de treino")]
        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]
        public String DataTermino { get; set; }

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
