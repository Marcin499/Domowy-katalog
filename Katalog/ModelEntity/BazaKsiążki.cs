using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.ModelEntity
{
   public class BazaKsiążki
    {
        public int Id { get; set; }

        public string Tytuł { get; set; }

        public string Autor { get; set; }

        public string Wydawnictwo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataWydania { get; set; }

        public string Gatunek { get; set; }

        public string SłowaKlucze { get; set; }
    }
}
