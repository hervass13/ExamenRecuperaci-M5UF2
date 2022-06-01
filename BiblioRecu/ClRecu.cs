using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioRecu
{
    public class ClRecu
    {
        private Hashtable taulaH = new Hashtable();

        public List<Int32> QuantesConsonants(String xs)
        {
            String consonants = "BCDFGHJKLMNÑPQRSTVWXYZ";
            int n = 0;
            List<Int32> llistaConsonantsMesRepetides = new List<Int32>();

            for (int i = 0; i < xs.Length; i++)
            {
                if(consonants.Contains(xs.Substring(i, 1).ToUpper()))
                {
                    if (!taulaH.Contains(xs[i]))
                    {
                        taulaH.Add(xs[i], 0);
                    }
                    ///si ya existia en a taula hash sumamos uno a su valor es decir si ya había una y ahora hemos
                    /// visto que hay otra, signifca que el value de esta consonante será 1, que quiere decir que se ha repetido
                    /// una vez es decir a salido dos veces.
                    else
                    {
                        taulaH[xs[i]] = ((Int32)taulaH[xs[i]]) + 1;
                    }
                }
            }

            foreach (char k in taulaH.Keys)
            {
                ///cojemos el value de la taulahash que pertenece a la key de la palabra que sea.
                n = (Int32)taulaH[k];

                llistaConsonantsMesRepetides.Add(n);
            }
            ///Ordena la lista pero queda de menos a mas
            llistaConsonantsMesRepetides.Sort();
            ///le hace el reverse para que quede de mas a menos
            llistaConsonantsMesRepetides.Reverse();

            return (llistaConsonantsMesRepetides);
        }

        public List<String> ParaulesMesRepetides(String xs1, String xs2)
        {
            List<String> llistaParaulesMesRepetides = new List<string>();
            int n = 0;
            String paraula = "";

            String[] vParaules1 = xs1.Split(' ');
            for (int i = 0; i < vParaules1.Length; i++)
            {
                if (!taulaH.Contains(vParaules1[i]))
                {
                    taulaH.Add(vParaules1[i], 0);
                }
            }

            String[] vParaules2 = xs2.Split(' ');
            for (int i = 0; i < vParaules2.Length; i++)
            {
                if (taulaH.Contains(vParaules2[i]))
                {
                    ///augemntamos el value de esa palabra que sería la key
                    taulaH[vParaules2[i]] = ((Int32)taulaH[vParaules2[i]]) + 1;
                }
            }
            foreach (String k in taulaH.Keys)
            {
                paraula = k;
                ///cojemos el value de la taulahash que pertenece a la key de la palabra que sea.
                n = (Int32)taulaH[k];
                ///hago este if para las palabras que solo están una vez, es decir, que no se repiten, no
                /// salgan en la llistaParaulesMesRepetides.
                if (n > 0) llistaParaulesMesRepetides.Add(n.ToString() + "#" + paraula);
            }
            ///Ordena la lista pero queda de menos a mas
            llistaParaulesMesRepetides.Sort();
            ///le hace el reverse para que quede de mas a menos
            llistaParaulesMesRepetides.Reverse();

            return (llistaParaulesMesRepetides);
        }

        public String Codifica(String xs, Int32 n)
        {
            String encodedAscii = "";

            foreach (char lletra in xs)
            {
                Int32 num = Convert.ToInt32(lletra);
                String lletraNum = num.ToString();
                ///el length retorna la longitud de la string contnado a partir de 1 porque no es un vector que empieza desde 0
                if (lletraNum.Length != n)
                {
                    while (lletraNum.Length != n)
                    {
                        ///añado ceros a la izquierda de el grupo de numeros que sería la letra que estoy gestionando ahora
                        ///y le meto un while para que vaya añadiendo zeros hasta que la longitud de mi letra en ascii sea igual a n
                        lletraNum = "0" + lletraNum;
                    }
                }
                encodedAscii += lletraNum;
            }

            return encodedAscii;
        }
        public String Descodifica(String xs, Int32 n)
        {
            String decodedAscii = "";
            int qttCaracters = xs.Length / n;

            for (int i = 0; i < qttCaracters; i++)
            {
                ///voy avanzando para cojer el grupo de numeros que toque y me lo pase a la letra que corresponde
                Int32 num = Convert.ToInt32(xs.Substring(n * i, n));

                decodedAscii += (char)num;
            }

            return decodedAscii;
        }
    }
}
