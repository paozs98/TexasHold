using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace ProyectoSO
{
    public class Class1
    {
            //Este conecta hacia el AD
            //Cambiar el path,username,y pass manual
            private static DirectoryEntry GetDirectoryEntry()
            {
                DirectoryEntry de = new DirectoryEntry();
                de.Path = "LDAP://192.168.220.128/CN=Users;DC=DMT,DC=local";
                de.Username = @"DMTF\Administrador";
                de.Password = "123Dmt14";
                return de;
            }
            //Este crea el usuario
            string CreateUserAccount(string userName, string userPassword)
            {
                string oGUID = string.Empty;
                try
                {
                    DirectoryEntry dirEntry = GetDirectoryEntry();
                    DirectoryEntry newUser = dirEntry.Children.Add("CN=" + userName, "user");
                    newUser.Properties["samAccountName"].Value = userName;
                    newUser.CommitChanges();
                    oGUID = newUser.Guid.ToString();

                    newUser.Invoke("SetPassword", new object[] { userPassword });
                    newUser.CommitChanges();
                    dirEntry.Close();
                    newUser.Close();
                }
                catch (System.DirectoryServices.DirectoryServicesCOMException E)
                {
                    //DoSomethingwith --> E.Message.ToString();

                }
                return oGUID;
            }
            //autentifica al usuario por el nombre de usuario solamente
            bool Authenticate(string userName)
            {
                DirectoryEntry de = GetDirectoryEntry();
                DirectorySearcher deSearch = new DirectorySearcher();
                deSearch.SearchRoot = de;
                deSearch.Filter = "(&(objectClass=user) (cn=" + userName + "))";
                SearchResultCollection results = deSearch.FindAll();
                if (results.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


    }

