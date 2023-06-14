using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ginasio.Models
{
    public class Administradores
    {

        /// <summary>
        /// Id do Administrador
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nome do administrador
        /// </summary>
        [StringLength(20)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("^[a-zA-ZÀ-ú- ]+$", ErrorMessage = "Insira um {0} válido")]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do administrador
        /// </summary>
        [StringLength(15)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("^[a-zA-ZÀ-ú- ]+$", ErrorMessage = "Insira um {0} válido")]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Idade do administrador
        /// </summary>
        [Range(18, 100, ErrorMessage = "A idade deve estar entre 18 e 100")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public int Idade { get; set; }


        /// <summary>
        /// Sexo do administrador
        /// </summary>
        [StringLength(1)]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("^[MFmf]{1}$", ErrorMessage = "Insira um {0} válido, do tipo M ou F")]
        public string Sexo { get; set; }

        /// <summary>
        /// Data de nascimento do administrador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de nascimento")]
        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]
        public string DataNascimento { get; set; }

        /// <summary>
        /// Morada do administrador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Morada")]
        [RegularExpression("^[a-zA-ZÀ-ú\\s]+\\s\\d{4}-\\d{3}$", ErrorMessage = "A {0} tem de ser da forma  NOME DA TERRA XXXX-XXX")]
        public string Morada { get; set; }

        /// <summary>
        /// Telemóvel do administrador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Telemóvel")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve ter entre {1} dígitos")]
        [RegularExpression("9[1236][0-9]{7}",
            ErrorMessage = "O número de {0} deve começar por 91, 92, 93 ou 96 e ter 9 dígitos")]
        //   c/ indicatico  ((+|00)[0-9]{2,5})?[0-9]{5,9}
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do administrador
        /// </summary>
        //NAO FUNCIONOU [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        //NAO FUNCIONOU [RegularExpression("[a-z._0-9]+gmail.com", ErrorMessage = "O {0} deve ser do tipo @gmail.com")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "O email tem de ter um formato válido")]
        [StringLength(40)]
        public string Email { get; set; }

        /// <summary>
        /// Data de contratação do administrador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Data de contratação")]

        [RegularExpression("^(?:(?:31\\/(?:0?[13578]|1[02]))|(?:(?:29|30)\\/(?:0?[1,3-9]|1[0-2]))|(?:29\\/0?2)|(?:(?:0?[1-9])|(?:1\\d)|(?:2[0-8]))\\/(?:0?[1-9]|1[0-2]))\\/(?:[1-9]\\d{3})$", ErrorMessage = "A data deve ser válida e do tipo XX/XX/XXXX")]

        public string DataContratacao { get; set; }

        /// <summary>
        /// Salário do administrador
        /// </summary>
        [DisplayName("Salário(em €)")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        //[StringLength(10)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "O {0} deve ser numérico")]
        //[Range(0, double.MaxValue, ErrorMessage = "O salário tem de ter um valor positivo")]
        public int Salario { get; set; }

        /// <summary>
        /// Nível de acesso ao sistema do administrador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("^(total|parcial|nenhum|Total|Parcial|Nenhum)$", ErrorMessage = "O {0} deve ser total, parcial ou nenhum")]
        public string NivelAcesso { get; set; }
    }
}
