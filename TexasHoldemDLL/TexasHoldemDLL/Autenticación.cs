using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace TexasHoldemDLL
{
    public class Autenticación
    {

        public bool autentificar(string usu, string pass)
        {
            string path = @"WS16";
            string dominio = @"WS16.local";
            string usuario = usu;
            string password = pass;
            string domUsua = dominio + @"\" + usuario;

            DirectoryEntry de = new DirectoryEntry(path, usuario, password, AuthenticationTypes.Secure);
            try
            {
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.FindOne();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
