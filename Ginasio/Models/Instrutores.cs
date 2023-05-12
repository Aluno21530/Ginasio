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
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do instrutor
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Idade do instrutor
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Sexo do instrutor
        /// </summary>
        public char Sexo { get; set; }

        /// <summary>
        /// Data de nascimento  do instrutor
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Morada do instrutor
        /// </summary>
        public string Morada { get; set; }

        /// <summary>
        /// Telemóvel do instrutor
        /// </summary>
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do instrutor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Data de contratação do instrutor
        /// </summary>
        public DateTime DataContratacao { get; set; }

        /// <summary>
        /// Área de especialização do instrutor
        /// </summary>
        public string Especializacao { get; set; }

        /// <summary>
        /// Salário do instrutor
        /// </summary>
        public float Salario { get; set; }

        /// <summary>
        /// Lista de aulas em que o instrutor leciona
        /// </summary>
        public ICollection<Aulas> ListaAulas { get; set; }

        /// <summary>
        /// Lista de treinamentos em que o instrutor leciona
        /// </summary>
        public ICollection<Treinamentos> ListaTreinamentos { get; set; }

    }
}
