using BiblioRecu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {

        String msg = "";
        String prova = "";
        String[] vdades;

        ClProveidorProves proveidor = null;
        ClRecu recu = new ClRecu();

        [TestMethod]
        public void QuantesConsonants()
        {
            List<Int32> llistaResultat = new List<Int32>();

            llistaResultat.Add(5);
            llistaResultat.Add(4);
            llistaResultat.Add(3);
            llistaResultat.Add(2);
            llistaResultat.Add(1);
            llistaResultat.Add(0);

            CollectionAssert.AreEqual(llistaResultat, recu.QuantesConsonants("bbbbbb ccccc dddd fff gg h"));
        }

        [TestMethod]
        public void TestParaulesMesRepetides()
        {
            List<String> llistaResultat = new List<String>();

            llistaResultat.Add("4#quart");
            llistaResultat.Add("3#tercer");
            llistaResultat.Add("2#sise");
            llistaResultat.Add("2#segon");
            llistaResultat.Add("1#primer");
            llistaResultat.Add("1#cinque");

            CollectionAssert.AreEqual(llistaResultat, recu.ParaulesMesRepetides("primer segon tercer quart cinque sise", "nove vuite sete sise sise cinque quart quart quart quart tercer tercer tercer segon segon primer"));
        }

        [TestMethod]
        public void provaCodifica()
        {
            proveidor = new ClProveidorProves("CriptoEncode.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 3)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova);
                    }
                    else
                    {
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Console.WriteLine(msg);
                        //msg = cripto.CriptoEncode(vdades[0], Int32.Parse(vdades[1]));
                        //Console.WriteLine(msg + "      yes     ");
                        Assert.AreEqual(vdades[2], recu.Codifica(vdades[0], Int32.Parse(vdades[1])), msg);

                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }

        [TestMethod]
        public void provaDescodifica()
        {
            proveidor = new ClProveidorProves("CriptoDecode.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 3)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova + vdades.Length);
                    }
                    else
                    {
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Console.WriteLine(msg);
                        //msg = recu.Descodifica(vdades[0], Int32.Parse(vdades[1]));
                        //Console.WriteLine(msg + "          yes");
                        Assert.AreEqual(vdades[2], recu.Descodifica(vdades[0], Int32.Parse(vdades[1])), msg);

                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }
    }
}
