using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer
{
    class Juego
    {
        //Atributos
        private Mazo m_baraja;
        private Casa m_casa;
        private coleccionJugador jugadores;

        //Metodos

        public coleccionJugador getJugadores()
        {
            return jugadores;
        }

        public Mazo getBaraja()
        {
            return m_baraja;
        }

        public Casa getCasa()
        {
            return m_casa;
        }

        public bool IniciarSesion(string id)
        {
            //Acá se verifica que el jugador este registrado en la base
            //Una vez verificada la sesión se le pide el monto de la apuesta
            //que viene por un socket, y se inicia el juego.
            bool existe = jugadores.VerificarJugador(id);
            return existe;
        }


        //La coleccion de nombres que le llega debe ser del activeD o de la interfaz
        //Si es de la interfaz debe haber alguna clase o forma para agregar los nuevos
        //jugadores

        public juego(coleccionJugador nombres)
        {
            //Coleccion de jugadores con la lista que le llega...
            jugadores = new coleccionJugador(nombres.obtenerCantidad());
            for (int i = 0; i < nombres.obtenerCantidad(); i++)
            {
                jugador j = nombres.obtenerJugador(i);
                jugadores.agregarJugador(j);
            }

            //Se crea el mazo
            m_baraja = new Mazo();

            //Se crea el jugador casa...
            m_casa = new Casa("Casa");

            //Se llena el mazo
            m_baraja.llenarMazo();

            //Se baraja el mazo
            m_baraja.barajar();

            //Se prepara el mazo general el juego
        }


        public juego(int num)
        {
            //Coleccion de jugadores con el numero de elementos que le llega
            jugadores = new coleccionJugador(num);

            //Se crea el mazo
            m_baraja = new Mazo();

            //Se crea el jugador casa...
            m_casa = new Casa("Casa");

            //Se llena el mazo
            m_baraja.llenarMazo();

            //Se baraja el mazo
            m_baraja.barajar();

            //Se prepara el mazo general el juego
        }


        public void jugar()
        {

            //Estos dos for dan las primeras dos cartas a todos los jugadores y a la casa...
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < jugadores.obtenerCantidad(); i++)
                {
                    m_baraja.darCarta(jugadores.obtenerJugador(i).obtenerMano());
                    //****Acá al repartir la mano a cada jugador se debe también enviar los valores
                    //*** de las cartas obtenidas a la interfaz
                    //(numCarta1, numCarta2, idJugador (y quizá baraja de cada una también))
                }
                //*** Se debe enviar también los valores obtenidos por la casa a la interfaz
                //*** estos valores se envían a todos los sockets conectados
                m_baraja.darCarta(m_casa.obtenerMano());
            }

            //La casa voltea sus cartas
            //m_casa.voltearPrimero();

            //Cada jugador muestra sus cartas
            //***Este metodo no iría a la interfaz dado que en esta
            //***ya los valores de las cartas se mostrarían de una vez
            for (int i = 0; i < jugadores.obtenerCantidad(); i++)
            {
                jugadores.obtenerJugador(i).toString();
            }


            //La casa muestra sus cartas
            m_casa.toString();




            //Cada jugador pide o se queda
            //**En la interfaz, por turnos, se pide al jugador si quiere seguir o quedarse
            for (int i = 0; i < jugadores.obtenerCantidad(); ++i)
            {
                //**Hay que modificar este método para que al llegar un de la interfaz:
                // 1-> Se queda
                // 0-> Sigue
                //Entonces se le pasaria al método un int
                //Acá se pide a la interfaz por algún método de socket
                // pedirCarta(idJugador) y recibe un 1 o un 0
                //Al tener la carta nueva el valor de esta se envía al
                //jugador a la interfaz, y vuelve a pedirCarta() del sig Jugador.
                m_baraja.cartaAdicional(jugadores.obtenerJugador(i));
                //Acá el jugador va a pedir hasta que decida quedarse o se 
                //haya pasado de 21 pts.

            }



            //Muestra la casa
            m_casa.toString();

            //Si mano de casa <= 16, pide carta
            //**Tiene que enviar los valores de la casa a la interfaz
            //para actualizar valores de la misma allá
            m_baraja.cartaAdicionalCasa(m_casa);


            //Para este punto del juego la casa ya debería haberse quedado o 
            //pasado de puntos, así que se va a comparar.

            //Compara valores de casa y jugadores
            /*
             * Si la casa se pasó de 21 se tiene que informar a la interfaz que
             * todos los jugadores ganan, por lo que el monto de sus apuestas también sube
             * y se manda luego una lista de jugadores y de montos de apuestas.
             */
            if (m_casa.pasoDe21())
            {
                for (int i = 0; i < jugadores.obtenerCantidad(); ++i)
                {
                    if (!(jugadores.obtenerJugador(i).pasoDe21()))
                    {
                        jugadores.obtenerJugador(i).gana();
                    }
                }
            }
            /*
             * En cada uno de los if se debe informar a los clientes los jugadores que pierden, ganan
             * o quedan empatados. Si quedan empatados igual pierden la apuesta.
             */
            else
            {
                for (int i = 0; i < jugadores.obtenerCantidad(); ++i)
                {
                    if (!jugadores.obtenerJugador(i).pasoDe21())
                    {
                        if (jugadores.obtenerJugador(i).obtenerMano().ObtenerTotal() > m_casa.obtenerMano().ObtenerTotal())
                        {
                            //Se llama acá un socket que envía el id de jugador y el mensaje de ganador.
                            // ganador(IdJugador y 0 -> ganó, saldoActualizado)
                            jugadores.obtenerJugador(i).gana();
                        }
                        else if (jugadores.obtenerJugador(i).obtenerMano().ObtenerTotal() < m_casa.obtenerMano().ObtenerTotal())
                        {
                            // ganador(IdJugador, 1 -> perdió, saldoActualizado);
                            //Se verifica si el saldo es 0 entonces hay que desconectar el socket de ese jugador
                            jugadores.obtenerJugador(i).pierde();
                        }
                        else
                        {
                            // ganador(IdJugador, 2-> push, saldoActualizado);
                            //Se verifica también el saldo
                            jugadores.obtenerJugador(i).push();
                        }
                    }
                }
            }
            //Se limpian las colecciones que hayan.
            //En la interfaz esto simula un reseteo de valores también.
            //En la interfaz se pregunta a los jugadores si quieren desconectarse o seguir jugando
            //Los valores de las respuestas vienen al servidor, si se recibe de un clientSocket que
            //este se quiere desconectar hay que desconectarlo del servidor.



            //for (int i = 0; i < jugadores.obtenerCantidad(); ++i)
            //Va la funcion de limpiar
            //funcion de limpiar de la casa
        }
    }
}

