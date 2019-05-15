using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebadll
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string opt;
                while (true)
                {
                    Console.WriteLine(string.Format("1-Registrar \n 2-Autenticar \n 3-salir"));
                    opt = Console.ReadLine();

                    Console.WriteLine("Nombre:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Pass:");
                    string dato = Console.ReadLine();

                    if (opt == "1")
                    {
                        Console.WriteLine("email:");
                        string email = Console.ReadLine();
                        ADDC.ADDC.CreateUserAccount(nombre, dato, email);
                    }
                    else
                    {
                        if (ADDC.ADDC.AuthenticateF(nombre, dato))
                        {
                            Console.Write("Autenticacion exitosa!!\n");
                        }
                        else
                        {
                            Console.Write("Fallo de autenticacion \n\n");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.ReadLine();
        }
    }
}
