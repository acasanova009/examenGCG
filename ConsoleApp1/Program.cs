

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

                Dinamico();


                break;

            case 3:

                Paginacion();
                break;

            case 4:

                Segmentacion();
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
    var nuevaParticion = 50;
    List<int> listaParticiones = new List<int>();
    List<int> listaProcesos = new List<int>();


    while (!salir)
    {

        try
        {
            Console.Clear();
            Console.WriteLine("******************************************************");
            Console.WriteLine("Particion de Memoria ESTATICO");
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
                if ((memoriaRestante - (totalParticiones - i -1) * nuevaParticion) <= 50)
                {
                    for (; i < totalParticiones; i++)
                    {
                        memoriaRestante = memoriaRestante - nuevaParticion;
                        listaParticiones.Add(50);
                    }
                    break;
                }

                Console.WriteLine("Elige tamaño para la siguiente particion " + i);
                Console.WriteLine("Max: " + (memoriaRestante - (totalParticiones - i - 1) * nuevaParticion) + "kb");
                Console.WriteLine("Min: 50kb");



                int tamanioParticionNueva = Convert.ToInt32(Console.ReadLine());
                while (tamanioParticionNueva <nuevaParticion  || tamanioParticionNueva > (memoriaRestante - (totalParticiones-i-1) * nuevaParticion))
                {

                    Console.WriteLine("*Error tamaño fuera de rango posible*");
                    Console.WriteLine("");
                    Console.WriteLine("Elige tamaño para la siguiente particion " + i);
                    Console.WriteLine("Max: " + (memoriaRestante - (totalParticiones - i - 1) * nuevaParticion) + "kb");
                    Console.WriteLine("Min: 50kb");

                    tamanioParticionNueva = Convert.ToInt32(Console.ReadLine());

                }
                memoriaRestante= memoriaRestante - tamanioParticionNueva;
                listaParticiones.Add(tamanioParticionNueva);

            }
            Console.Clear();
            Console.WriteLine("------------------Estado de PARTICIONES---------------------");
            Console.WriteLine("");
            Console.WriteLine("Particiones totales son: " + totalParticiones);
            int j = 0;


            

            int nuevoProcesso;


            foreach (var particion in listaParticiones)
            {
                Console.WriteLine("Particion: "+j + " "+particion);

               

                j++;
            }
            if (memoriaRestante>0)
            {
                Console.WriteLine("Particion Vacia:   " + memoriaRestante);
                
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("Agregar Procesos a las PARTICIONES: ");
            Console.WriteLine("-------------------------- ");
            j = 0;

            foreach (var particion in listaParticiones)
            {
                Console.WriteLine("Particion: " + j + " -> Maximo de memoria:" + particion);

                Console.WriteLine("Nuevo Proceso:");
                nuevoProcesso = Convert.ToInt32(Console.ReadLine());

                while (nuevoProcesso < 0 || nuevoProcesso > particion)
                {

                    Console.WriteLine("*Error tamaño de processo*, ");
                    Console.WriteLine("Tiene que ser de 0 a " + particion);

                    nuevoProcesso = Convert.ToInt32(Console.ReadLine());

                }

                listaProcesos.Add(nuevoProcesso);

                j++;
            }


            





            Console.WriteLine("------------------Estado del sistema Operativo con Procesos---------------------");
            Console.WriteLine("");
            Console.WriteLine("Particiones totales son: " + totalParticiones);
            int k = 0;
            var enumeratorProcesos = listaProcesos.GetEnumerator();
            
           

            foreach (var particion in listaParticiones)
            {
                enumeratorProcesos.MoveNext();
                Console.WriteLine("Particion: " + k + " [" + particion+"]   Proceso:  " + enumeratorProcesos.Current);
                
                k++;

            }
            if (memoriaRestante > 0)
            {
                Console.WriteLine("Particion Vacia:   " + memoriaRestante);

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

int Dinamico()
{
    int memoriaRestante = 2048;

    bool salir = false;
    
    List<int> listaParticiones = new List<int>();


    while (!salir)
    {

        try
        {
            Console.Clear();
            Console.WriteLine("******************************************************");
            Console.WriteLine("Particion de Memoria DINAMICO");
            Console.WriteLine("");
            Console.WriteLine("Memoria por segmentar restante " + memoriaRestante);
            Console.WriteLine("");
            Console.WriteLine("******************************************************");
            Console.WriteLine("");
            Console.WriteLine("");



           
            int nuevaParticion;
            bool seguirIntentaoAgregarNuevasParticiones = true;
            do
            {
                Console.WriteLine("Ingresa valor de siguiente particion");
                Console.WriteLine("Escribe de 1 a " + memoriaRestante);
                nuevaParticion = Convert.ToInt32(Console.ReadLine());
                while (nuevaParticion < 1)
                {
                    Console.WriteLine("Tiene que ser mayor a 0");
                    nuevaParticion = Convert.ToInt32(Console.ReadLine());

                }
                if (nuevaParticion <= memoriaRestante)
                {

                    listaParticiones.Add(nuevaParticion);
                    memoriaRestante-= nuevaParticion;
                }
                else
                {
                    Console.WriteLine("Se excedio necesidad de memoria, se incia el SO con los procesos validos");
                    seguirIntentaoAgregarNuevasParticiones = false;
                }

            } while (seguirIntentaoAgregarNuevasParticiones && memoriaRestante>0);
            
            

           
            Console.WriteLine("------------------Estado del sistema Operativo---------------------");
            Console.WriteLine("");
            int j = 1;
            foreach (var particion in listaParticiones)
            {
                Console.WriteLine("Particion: " + j + " Proceso: " + particion);
                j++;
            }
            if (memoriaRestante > 0)
            {
                Console.WriteLine("Particion Vacia: " + j + " " + memoriaRestante);

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

int Paginacion()
{
    int memoriaRestante = 2048;

    bool salir = false;




    while (!salir)
    {

        try
        {
            Console.WriteLine("PAGINACION");
            Console.WriteLine("Escribe el tamaño de marco");


            Console.WriteLine("Escribe de 1 a 2048");
            int marco = Convert.ToInt32(Console.ReadLine());
            while (marco < 1 || marco > 2048)
            {
                Console.WriteLine("Elige un numero en el interalo de 1 a 2048");
                marco = Convert.ToInt32(Console.ReadLine());

            
            }
            double totalMarcos = memoriaRestante / (double)marco;
            totalMarcos=Math.Floor(totalMarcos);
            Console.WriteLine("Total marcos: " + totalMarcos );

            Console.WriteLine("Memoria restante: " + (memoriaRestante - totalMarcos*marco));
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

int Segmentacion()
{
    int memoriaRestante = 2048;

    bool salir = false;




    while (!salir)
    {

        try
        {
            Console.WriteLine("SEGMENTACION");
            Console.WriteLine("Escribe el CANTIDAD de nuevos procesos de 1 a 1000");


            int totalProcesos = Convert.ToInt32(Console.ReadLine());
            while (totalProcesos < 1 || totalProcesos > 1000)
            {
                Console.WriteLine("Elige un numero en el interalo de 1 a 1000");
                totalProcesos = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("EXITO: Procesos por crear: " + totalProcesos);
            Console.WriteLine("");
            Console.WriteLine("");

            int procesos = 0;
            for (int i = 0; i < totalProcesos; i++)
            {
                Console.WriteLine("------------ ");
                Console.WriteLine("Ingresa el valor del nuevo proceso" + i);
                procesos = Convert.ToInt32(Console.ReadLine());
                while (procesos < 1 || procesos > 2048)
                {
                    Console.WriteLine("Elige un numero en el interalo de 1 a 2048");
                    procesos = Convert.ToInt32(Console.ReadLine());


                    




                }
               
                Console.WriteLine("Procentaje del proceso " +i);
                Console.WriteLine("S. Codigo  " + 0.3 * (double)procesos);
                Console.WriteLine("S. Data  " + 0.5 * (double)procesos);
                Console.WriteLine("S. Pila  " + 0.2 * (double)procesos);

                Console.WriteLine("------------ ");



            }
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