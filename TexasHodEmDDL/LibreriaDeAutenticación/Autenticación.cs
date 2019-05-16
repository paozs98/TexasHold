using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;


namespace LibreriaDeAutenticación
{
    public class Autenticación
    {
        private string path;
        private string dominio;
        private string usuario;
        private string password;
        private string domUsua;

        public Autenticación(string usu, string pass){
            path = @"WS16";
            dominio = @"WS16.local";
            usuario = usu;
            password = pass;
            domUsua = dominio + @"\" + usuario;
        }

        public bool autetificar()
        {
            bool res = false;
            res = autenticaUsuario(path, domUsua, password);
            return res;
        }

        public bool autenticaUsuario(string pat, string domUs, string pass)
        {
            DirectoryEntry de = new DirectoryEntry(pat, domUs, pass, AuthenticationType.Security);
        }
    }
}
