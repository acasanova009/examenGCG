﻿

bool salir = false;

while (!salir)
{

    try
    {
        Console.WriteLine("******************************************************");
        Console.WriteLine("AlfonSO");
        Console.WriteLine("Memoria total 4096 kb");
        Console.WriteLine("Memoria base 640 kb");
        Console.WriteLine("Memoria SO 2048 kb");
        Console.WriteLine("Memoria Procesos 2048 kb");
        Console.WriteLine("");
        Console.WriteLine("******************************************************");
        Console.WriteLine("");
        Console.WriteLine("Elegir tipo de particionamiento:");
        Console.WriteLine("");

        Console.WriteLine("1. Estático");
        Console.WriteLine("2. Dinámico");
        Console.WriteLine("3. Paginación");
        Console.WriteLine("4. Segmentación");
      
        Console.WriteLine("******************************************************");
        Console.WriteLine("0. Apagar computadora.");
        Console.WriteLine("******************************************************");

        Console.WriteLine("Elige una de las opciones");
        int opcion = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        switch (opcion)
        {
            case 1:

                Estatico();


                break;
            case 2:




                break;

            case 3:


                break;

            case 4:
                
                break;


            case 0:
                salir = true;
                break;

            default:
                Console.WriteLine("Elige una opcion correcta del menu");
                Console.WriteLine("Error 001");
                break;
        }

    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
        Console.Clear();
        Console.WriteLine("--------------------***********************Elige una opcion correcta del menu");
        Console.WriteLine("Error 001");
    }
}


int Estatico()
{
    int memoriaRestante = 2048;

    bool salir = false;
    var nuevoProceso = 50;
    List<int> listaParticiones = new List<int>();


    while (!salir)
    {

        try
        {
            Console.Clear();
            Console.WriteLine("******************************************************");
            Console.WriteLine("Particion de Memoria Estatico");
            Console.WriteLine("");
            Console.WriteLine("Memoria por segmentar restante " + 2048);
            Console.WriteLine("");
            Console.WriteLine("******************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("¿Cuantas particiones se requiere?");




            Console.WriteLine("Escribe de 1 a 40");
            int totalParticiones = Convert.ToInt32(Console.ReadLine());
            while (totalParticiones < 1 || totalParticiones > 40)
            {
                Console.WriteLine("Elige un numero en el interalo de 1 a 40");
                totalParticiones = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("EXITO: Particiones totales son: "+ totalParticiones);
            Console.WriteLine("");
            Console.WriteLine("");


            for (int i = 0; i < totalParticiones; i++) {
                if ((memoriaRestante - (totalParticiones - i -1) * nuevoProceso) <= 50)
                {
                    for (; i < totalParticiones; i++)
                    {
                        memoriaRestante = memoriaRestante - nuevoProceso;
                        listaParticiones.Add(50);
                    }
                    break;
                }

                Console.WriteLine("Elige tamaño para la siguiente particion " + i);
                Console.WriteLine("Max: " + (memoriaRestante - (totalParticiones - i - 1) * nuevoProceso) + "kb");
                Console.WriteLine("Min: 50kb");



                int tamanioParticionNueva = Convert.ToInt32(Console.ReadLine());
                while (tamanioParticionNueva <nuevoProceso  || tamanioParticionNueva > (memoriaRestante - (totalParticiones-i-1) * nuevoProceso))
                {

                    Console.WriteLine("*Error tamaño fuera de rango posible*");
                    Console.WriteLine("");
                    Console.WriteLine("Elige tamaño para la siguiente particion " + i);
                    Console.WriteLine("Max: " + (memoriaRestante - (totalParticiones - i - 1) * nuevoProceso) + "kb");
                    Console.WriteLine("Min: 50kb");

                    tamanioParticionNueva = Convert.ToInt32(Console.ReadLine());

                }
                memoriaRestante= memoriaRestante - tamanioParticionNueva;
                listaParticiones.Add(tamanioParticionNueva);

            }
            Console.Clear();
            Console.WriteLine("------------------Estado del sistema Operativo---------------------");
            Console.WriteLine("");
            Console.WriteLine("Particiones totales son: " + totalParticiones);
            int j = 1;
            foreach (var particion in listaParticiones)
            {
                Console.WriteLine("Particion: "+j + " Proceso: "+particion);
                j++;
            }
            if (memoriaRestante>0)
            {
                Console.WriteLine("Particion Vacia: " + j + " Proceso: " + memoriaRestante);
                
            }
            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine("");
            salir = true;

            

        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            Console.Clear();
            Console.WriteLine("--------------------***********************Fallo en la inicializacion del sistema, se regreso al menu principal.");
            Console.WriteLine("Error 002");
        }
    }

    return 0;
}