﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ginasio.Models
{
    public class Aulas
    {
        public Aulas()
        {
            ListaPraticantes = new HashSet<Praticantes>();
        }

        /// <summary>
        /// Id da aula
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da aula
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Breve descrição sobre a aula
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Horário de início da aula
        /// </summary>
        public DateTime Horario { get; set; }

        /// <summary>
        /// Duração da aula
        /// </summary>
        public int Duracao { get; set; }

        /// <summary>
        /// Capacidade máxima de participantes da aula
        /// </summary>
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
        public ICollection<Praticantes> ListaPraticantes { get; set; }

    }
}