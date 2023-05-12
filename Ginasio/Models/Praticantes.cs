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
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do praticante
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Idade do praticante
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Sexo do praticante
        /// </summary>
        public char Sexo { get; set; }

        /// <summary>
        /// Data de nascimento do praticante
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Morada do praticante
        /// </summary>
        public string Morada { get; set; }

        /// <summary>
        /// Telemóvel do praticante
        /// </summary>
        public string Telemovel { get; set; }

        /// <summary>
        /// Email do praticante
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Data de inscrição do praticante
        /// </summary>
        public DateTime DataInscricao { get; set; }

        /// <summary>
        /// Plano de treinamento do praticante
        /// </summary>
        public string PlanoTreinamento { get; set; }

        /// <summary>
        /// Situação financeira do praticante
        /// </summary>
        public string StatusPagamento { get; set; }

        /// <summary>
        /// Lista de aulas em que o praticante participa
        /// </summary>
        public ICollection<Aulas> ListaAulas { get; set; }

        /// <summary>
        /// Lista de treinamentos que o praticante participa
        /// </summary>
        public ICollection<Treinamentos> ListaTreinamentos { get; set; }
    }
}
