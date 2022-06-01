using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    class ClProveidorProves
    {
        public StreamReader fitxer;

        public ClProveidorProves(String xnomfitxer)
        {
            if (File.Exists(xnomfitxer))
            {
                fitxer = new StreamReader(xnomfitxer);
            }
            else
            {
                MessageBox.Show("No trobo el fitxer " + xnomfitxer, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fitxer = null;
            }
        }

        public String NextProva()
        {
            String xs = "";

            if (!fitxer.EndOfStream)
            {
                xs = fitxer.ReadLine();
            }
            else
            {
                fitxer.Close();
            }
            return (xs);
        }

        public void TancarProveidor()
        {
            fitxer.Close();
        }
    }
}
