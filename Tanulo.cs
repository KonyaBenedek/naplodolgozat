using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Tanulo

    {

        public string Nev { get; set; }

        public string Osztaly { get; set; }

        public char Nem { get; set; }

        public double Atlag { get; set; }

        public Tanulo(string sor)

        {

            string[] resz = sor.Split(';');

            Nev = resz[0];

            Osztaly = resz[1];

            Nem = Convert.ToChar(resz[2]);

            Atlag = Convert.ToDouble(resz[3]);

        }

    }
}
