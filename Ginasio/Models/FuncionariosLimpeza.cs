using System.ComponentModel.DataAnnotations.Schema;

namespace Ginasio.Models
{
    public class FuncionariosLimpeza
    {

        /// <summary>
        /// nome do funcionário
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do funcionário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do funcionário
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Idade do funcionário
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Sexo do funcionário
        /// </summary>
        public char Sexo { get; set; }

        /// <summary>
        /// Data de nascimento do funcionário
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Morada do funcionário
        /// </summary>
        public string Morada { get; set; }

        /// <summary>
        /// Telemóvel do funcionário
        /// </summary>
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do funcionário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Data de contratação do funcionário
        /// </summary>
        public DateTime DataContratacao { get; set; }

        /// <summary>
        /// Salário  do funcionário
        /// </summary>
        public float Salario { get; set; }

        /// <summary>
        /// Chave forasteira(FK) referente ao administrador responsável pelo funcionário
        /// </summary>
        [ForeignKey(nameof(Administrador))]
        public int AdmFK { get; set; }
        public Administradores Administrador { get; set; }
    }
}
