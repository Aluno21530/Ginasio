using FluentAssertions.Common;
using Ginasio.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ginasio.Data
{

    /// <summary>
    /// esta classe representa a Base de Dados do nosso projeto
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        /* *********************************************
         * Criação das Tabelas
         * ********************************************* */
        public DbSet<Administradores> Administradores { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<FuncionariosLimpeza> FuncionariosLimpeza { get; set; }
        public DbSet<Instrutores> Instrutores { get; set; }
        public DbSet<Usuarios> Praticantes { get; set; }
        public DbSet<Treinamentos> Treinamentos { get; set; }
        public DbSet<Ginasio.Models.Fotografias> Fotografias { get; set; } = default!;

    }
}