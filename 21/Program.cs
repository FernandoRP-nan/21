Boolean decisionJ;

String[] cartas = new String[52];
int[] elegidos = new int[52];
int[] cartasDelJugador = new int[52];
int[] cartasDeLaCasa = new int[3];

int counter = 0, counter2 = 0, counter3 = 0, counter4 = 0;

int jugadorTotal = 0, casaTotal = 0;

Boolean fin = false;

do
{


    counter = 0; counter2 = 0; counter3 = 0; counter4 = 0;

    jugadorTotal = 0; casaTotal = 0;

    fin=false;

    // Guardamos las cartas en un arreglo del .txt
    foreach (string line in System.IO.File.ReadLines(@"c:\envidencia3.txt"))
    {
        System.Console.WriteLine(counter+1+") "+line);
        cartas[counter++] = line;
    }
    //System.Console.WriteLine("There were {0} lines.", counter);


    //Escoges una carta y esta se anula del juego.
    System.Console.WriteLine("¿Cuál carta escoges?");
    int eleccion = Convert.ToInt32(Console.ReadLine());
    cartas[eleccion] = "CERO";
    elegidos[counter2++] = eleccion;

    //Se escoge una al azar, si coincide con la que se escogió, se repite hasta que no.
    var randomNumber = nuevo();
    //System.Console.WriteLine(randomNumber);
    cartas[randomNumber] = "CERO";


    //Asignamos dos cartas del arreglo a la CASA.
    asignarCartaCasa();
    asignarCartaCasa();
    comprobarSiSePasoLaCasa();
    if (fin)
        break;
    System.Console.WriteLine("Ya se asignaron las cartas de la casa");

    Console.ReadLine();

    //Asignamos dos cartas al jugador y se las mostramos.
    asignarCarta();
    asignarCarta();

    System.Console.WriteLine(cartas[cartasDelJugador[0]] + " y " + cartas[cartasDelJugador[1]] + " con valor de: " + jugadorTotal);

    comprobarSiSePasoElJugador();
    if (fin)
    {
        volverAJugar();
        break;
    }

    Console.ReadLine();

    System.Console.WriteLine("La primera carta de la casa es: " + cartas[cartasDeLaCasa[0]]);

    Boolean decision;
    do
    {
        System.Console.WriteLine("¿Desea otra carta? \n1)Si \n2)No");
        decision = (Console.ReadLine() == "1");
        if (decision)
        {
            asignarCarta(); 
            System.Console.WriteLine("Su carta es: " + cartas[cartasDelJugador[counter3 - 1]]);
            comprobarSiSePasoElJugador();
            if (fin)
                break;

        }
            

    } while (decision);

    System.Console.WriteLine("La segunda carta de la casa es: " + cartas[cartasDeLaCasa[1]]);
    if (casaTotal < 16)
    {
        asignarCartaCasa();
        System.Console.WriteLine("La tercera carta de la casa es: " + cartas[cartasDeLaCasa[2]]);
        comprobarSiSePasoLaCasa();
    }

    ganador();


    // Suspend the screen.  
    System.Console.ReadLine();


    int nuevo()
    {
        int nuevo_ale;
        do
        {
            nuevo_ale = new Random().Next(1, 52);
        } while (comprobar_lista(nuevo_ale));

        elegidos[counter2++] = nuevo_ale;
        return nuevo_ale;
    }

    Boolean comprobar_lista(int numeroComprobar)
    {
        for (int i = 0; i < elegidos.Length; i++)
        {
            if (numeroComprobar == elegidos[i] || cartas[numeroComprobar] == "CERO")
            {
                return true;
            }
        }
        return false;
    }

    void asignarCarta()
    {
        cartasDelJugador[counter3] = nuevo();
        jugadorTotal += darValor(cartasDelJugador[counter3]);
        //comprobarSiSePasoElJugador();
        counter3++;
    }

    void asignarCartaCasa()
    {
        cartasDeLaCasa[counter4] = nuevo();
        casaTotal += darValor(cartasDeLaCasa[counter4]);
        //System.Console.WriteLine(casaTotal);
        counter4++;
    }

    int darValor(int valor)
    {
        valor++;
        if (valor < 14)
        {

        }
        else if (valor < 27)
        {
            valor = valor - 13;
        }
        else if (valor < 40)
        {
            valor = valor - 26;
        }
        else
        {
            valor = valor - 39;
        }

        //System.Console.WriteLine("El valor que regresa es " + valor);
        return valor;
    }

    void comprobarSiSePasoElJugador()
    {
        if (jugadorTotal > 21)
        {
            System.Console.WriteLine("Perdiste, Fin del juego");
            fin = true;
            
        }
        else
        {
            System.Console.WriteLine("Llevas " + jugadorTotal);
        }
    }

    void comprobarSiSePasoLaCasa()
    {
        if (casaTotal > 21)
        {
            System.Console.WriteLine("Ganaste, la casa se pasó con: " + casaTotal);
            fin = true;
        }
        else
        {
            //System.Console.WriteLine("La casa lleva " + casaTotal);
        }
    }

    void ganador()
    {
        if (fin==false)
        {
            if (casaTotal > jugadorTotal)
            {
                System.Console.WriteLine("Perdiste, la casa sacó " + casaTotal + " y tú " + jugadorTotal);
            }
            else if (casaTotal == jugadorTotal)
            {
                System.Console.WriteLine("Empate, la casa sacó " + casaTotal + " y tú " + jugadorTotal);
            }
            else
            {
                System.Console.WriteLine("Ganaste, la casa sacó " + casaTotal + " y tú " + jugadorTotal);
            }
        }
        
    }






    volverAJugar();


} while (decisionJ);

void volverAJugar()
{
    System.Console.WriteLine("¿Desea volver a jugar? \n1)Si \n2)No");
    decisionJ = (Console.ReadLine() == "1");
}