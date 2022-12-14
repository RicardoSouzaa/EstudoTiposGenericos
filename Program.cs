using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposGenericos
{
    class Program
    {
        static void Main(string[] args)
        {
            var macho = new Cachorro();
            var femea = new Cachorro();
            var filhote = Cruzar(macho, femea);
            filhote.Peso = 10;
            filhote.Raca = "PINCHER";
            filhote.Mae.Raca = "PITIBULL";
            filhote.Pai.Raca = "SALSICHA";

            Console.WriteLine($"Pai {macho.Raca}, Mãe {femea.Raca}, Filhote {filhote.Raca} pesa {filhote.Peso} ");
            Console.ReadLine();
        }

        public static T Cruzar<T>(T macho, T femea) where T : Mamiferos<T>
        {
            var filhote = Activator.CreateInstance<T>();
            filhote.Pai = macho;
            filhote.Mae = femea;
            return filhote;
        }
    }

    //classe genérica que será herdada pelas outras classes.
    public abstract class Mamiferos<T> where T : Mamiferos<T>
    {
        public T Pai { get; set; }
        public T Mae { get; set; }
        public decimal Peso { get; set; }
    }

    public class Cachorro : Mamiferos<Cachorro>
    {
        public string Raca { get; set; }
    }

    public class Gato : Mamiferos<Gato>
    {
        public string Raca { get; set; }
        public int Bigode { get; set; }
    }

    public class Elefante : Mamiferos<Elefante>
    {
        public int Tromba { get; set; }
    }
}