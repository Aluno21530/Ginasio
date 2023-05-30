using System.ComponentModel.DataAnnotations.Schema;

namespace Ginasio.Models
{

    /// <summary>
    /// Fotografias associadas aos praticantes e instrutores
    /// </summary>
    public class Fotografias
    {

        public int Id { get; set; }

        /// <summary>
        /// Nome do documento com a fotografia do instrutor/praticante
        /// </summary>
        public string NomeFicheiro { get; set; }


        //**********************************************

        /// <summary>
        /// FK para identificar o Praticante a quem a Fotografia pertence 
        /// </summary>
        [ForeignKey(nameof(Praticante))]  // <=>  [ForeignKey("Animal")]
        public int PraticanteFK { get; set; }
        public Praticantes Praticante { get; set; }

        /// <summary>
        /// FK para identificar o Instrutor a quem a Fotografia pertence 
        /// </summary>
        [ForeignKey(nameof(Instrutor))]  // <=>  [ForeignKey("Animal")]
        public int InstrutorFK { get; set; }
        public Instrutores Instrutor { get; set; }




    }
}
