using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace TexasHoldemDLL
{
    public static class Autenticación
    {

        public static bool autentificar(string usu, string pass)
        {

            string path = @"LDAP://WS16.local/TexasHoldEm/Usuarios"; //Sino funciona intentar con...
            string dominio = @"WS16";                    //OU=Usuarios,OU=TexasHoldEm,DC=WS16,DC=local
            string usuario = usu;
            string password = pass;
            string domUsua = dominio + @"\" + usuario;

            DirectoryEntry entrada = new DirectoryEntry(path, domUsua, password, AuthenticationTypes.Secure);
            try
            {
                DirectorySearcher busca = new DirectorySearcher(entrada);
                busca.FindOne();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool crearUsuario(string usu, string pass)
        {

            string path = @"LDAP://WS16.local/TexasHoldEm/Usuarios"; //Sino funciona intentar con... OU=Usuarios,OU=TexasHoldEm,DC=WS16,DC=local

            //string oGUID = string.Empty;  //Tambien se puede intentar liberando los comentasios de oGID y cambiando al metodo para que devuelva string

            try { 

                DirectoryEntry entrada  = new DirectoryEntry(path);

                DirectoryEntry nuevoUsuario = entrada.Children.Add("CN=" + usu, entrada.SchemaClassName);
                nuevoUsuario.Properties["samAccountName"].Value = usu;
                nuevoUsuario.CommitChanges();
                //oGUID = nuevoUsuario.Guid.ToString();

                nuevoUsuario.Invoke("SetPassword", new object[] { pass });
                nuevoUsuario.CommitChanges();
                entrada.Close();
                nuevoUsuario.Close();

                return true;
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //E.Message.ToString();
                return false;
            }
            //return oGUID;
        }

    }
}