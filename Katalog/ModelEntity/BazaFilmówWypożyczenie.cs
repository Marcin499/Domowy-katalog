using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.ModelEntity
{
  public class BazaFilmówWypożyczenie
    {
        public int Id { get; set; }

        public string Imię { get; set; }

        public string Nazwisko { get; set; }

        public string Tytuł { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataWypozyczenia { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataZwrotu { get; set; }        
    }
}
