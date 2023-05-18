using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ginasio.Models
{
    public class Praticantes
    {
        public Praticantes()
        {
            ListaAulas = new HashSet<Aulas>();
            ListaTreinamentos = new HashSet<Treinamentos>();
        }

        /// <summary>
        /// Id do praticante
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do praticante
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do praticante
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O sobrenome deve conter apenas letras")]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Idade do praticante
        /// </summary>
        [Range(18, 100, ErrorMessage = "A idade deve estar entre 18 e 100")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public int Idade { get; set; }

        /// <summary>
        /// Sexo do praticante
        /// </summary>
        [StringLength(1)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("^[MFmf]{1}$", ErrorMessage = "Insira um {0} válido, do tipo M ou F")]
        public string Sexo { get; set; }

        /// <summary>
        /// Data de nascimento do praticante
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de nascimento")]
        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]
        public string DataNascimento { get; set; }

        /// <summary>
        /// Morada do praticante
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Morada")]
        [RegularExpression("^[a-zA-ZÀ-ú\\s]+\\s\\d{4}-\\d{3}$", ErrorMessage = "A {0} tem de ser da forma  NOME DA TERRA XXXX-XXX")]
        public string Morada { get; set; }

        /// <summary>
        /// Telemóvel do praticante
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Telemóvel")]
        [StringLength(9, MinimumLength = 6,
                      ErrorMessage = "O {0} deve ter {1} dígitos")]
        [RegularExpression("9[1236][0-9]{7}",
                            ErrorMessage = "O número de {0} deve começar por 91, 92, 93, 96 e ter 9 dígitos")]
        //                ((+|00)[0-9]{2,5})?[0-9]{5,9}
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do praticante
        /// </summary>
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "O email tem de ter um formato válido")]
        [StringLength(40)]
        public string Email { get; set; }

        /// <summary>
        /// Data de inscrição do praticante
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de inscrição")]
        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]
        public string DataInscricao { get; set; }

        /// <summary>
        /// Plano de treinamento do praticante
        /// </summary>
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "O plano de treinamento deve conter apenas letras e espaços")]
        public string PlanoTreinamento { get; set; }

        /// <summary>
        /// Situação financeira do praticante
        /// </summary>
        [RegularExpression("^(ativo|inativo)$", ErrorMessage = "O status de pagamento deve ser 'ativo' ou 'inativo'")]
        public string StatusPagamento { get; set; }

        /// <summary>
        /// Lista de aulas em que o praticante participa
        /// </summary>
        public ICollection<Aulas> ListaAulas { get; set; }

        /// <summary>
        /// Lista de treinamentos que o praticante participa
        /// </summary>
        public ICollection<Treinamentos> ListaTreinamentos { get; set; }

        /// <summary>
        /// lista das fotografias associadas a um praticante
        /// </summary>
        public ICollection<Fotografias> ListaFotografias { get; set; }
    }
}
