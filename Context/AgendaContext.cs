using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio_Projeto_MVC_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Dio_Projeto_MVC_DotNet.Context
{
    public class AgendaContext : DbContext  
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base (options)
        {

        }

        public DbSet<Contato> Contatos {get; set;}
    }
}