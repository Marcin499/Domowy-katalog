using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.ModelEntity
{
    public class ModelContext: DbContext
    {
        public ModelContext() : base(@"Data Source=MARCIN;Initial Catalog=Biblioteka;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public DbSet<BazaFilmy> Filmy { get; set; }
        public DbSet<BazaFilmówWypożyczenie>FilmyWypożyczenie { get; set; }
        public DbSet<BazaKsiążki> BazaKsiążki { get; set; }
        public DbSet<BazaKsiążekWypożyczenie> KsiążkiWypożyczenie { get; set; }
        public DbSet<BazaMuzyka> BazaMuzyka { get; set; }
        public DbSet<BazaMuzykiWypożyczenie> MuzykaWypozyczenie { get; set; }
    }
}
