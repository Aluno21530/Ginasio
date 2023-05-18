using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ginasio.Models
{
    public class Instrutores
    {
        public Instrutores()
        {
            ListaAulas = new HashSet<Aulas>();
            ListaTreinamentos = new HashSet<Treinamentos>();
        }

        /// <summary>
        /// Id do instrutor
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do instrutor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do instrutor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "O sobrenome deve conter apenas letras")]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Idade do instrutor
        /// </summary>
        [Range(18, 100, ErrorMessage = "A idade deve estar entre 18 e 100")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public int Idade { get; set; }

        /// <summary>
        /// Sexo do instrutor
        /// </summary>
        [StringLength(1)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("^[MFmf]{1}$", ErrorMessage = "Insira um {0} válido, do tipo M ou F")]
        public string Sexo { get; set; }

        /// <summary>
        /// Data de nascimento  do instrutor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de nascimento")]
        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]
        public string DataNascimento { get; set; }

        /// <summary>
        /// Morada do instrutor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Morada")]
        [RegularExpression("^[a-zA-ZÀ-ú\\s]+\\s\\d{4}-\\d{3}$", ErrorMessage = "A {0} tem de ser da forma  NOME DA TERRA XXXX-XXX")]
        public string Morada { get; set; }

        /// <summary>
        /// Telemóvel do instrutor
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
        /// Email do instrutor
        /// </summary>
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "O email tem de ter um formato válido")]
        [StringLength(40)]
        public string Email { get; set; }

        /// <summary>
        /// Data de contratação do instrutor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de contratação")]

        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]

        public string DataContratacao { get; set; }

        /// <summary>
        /// Área de especialização do instrutor
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ\s]+$", ErrorMessage = "A especialização deve conter apenas letras.")]
        public string Especializacao { get; set; }

        /// <summary>
        /// Salário do instrutor
        /// </summary>
        //[Range(0, double.MaxValue, ErrorMessage = "O salário tem de ter um valor positivo")]
        [DisplayName("Salário(em €)")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        //[StringLength(10)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "O {0} deve ser numérico")]
        public float Salario { get; set; }

        /// <summary>
        /// Lista de aulas em que o instrutor leciona
        /// </summary>
        public ICollection<Aulas> ListaAulas { get; set; }

        /// <summary>
        /// Lista de treinamentos em que o instrutor leciona
        /// </summary>
        public ICollection<Treinamentos> ListaTreinamentos { get; set; }

        /// <summary>
        /// lista das fotografias associadas a um instrutor
        /// </summary>
        public ICollection<Fotografias> ListaFotografias { get; set; }

    }
}
