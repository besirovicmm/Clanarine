using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clanarine
{
    [Serializable]
    class Osoba
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string imeIPrezime 
        {
            get  => $"{Ime} {Prezime}";

        }
        private DateTime clanarina;
        public DateTime Clanarina 
        {
            get => clanarina;

            set
            {
                clanarina = value;
             
            }
        } 

        public Osoba()
        {

        }

    }
}
