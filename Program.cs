
//Menú principal
int opcionPrincipal;
int pedidosRealizados = 0;
decimal recaudacion = 0;
decimal pedidoMasCaro = 0;
string clientePedidoMasCaro = "";

do
{
    Console.WriteLine();
    Console.WriteLine("===================");
    Console.WriteLine(" Reparaciones RAW");
    Console.WriteLine("===================");
    Console.WriteLine();
    Console.WriteLine("1. Empezar un pedido");
    Console.WriteLine("2. Pedidos del día");
    Console.WriteLine("0. Salir");
    Console.WriteLine();
    Console.Write("Selecciona una opcion: ");
    opcionPrincipal = int.Parse(Console.ReadLine()!);



    //Informacion cliente
    string nombreCliente;

    if (opcionPrincipal == 1)
    {
        do
        {
            Console.WriteLine("Nuevo pedido");
            Console.WriteLine();
            Console.WriteLine("Introduzca nombre: ");

            nombreCliente = Console.ReadLine() ?? "";
            if (nombreCliente.Trim() == "")
            {
                Console.WriteLine("El nombre no puede estar vacío.");
            }
        }
        while (nombreCliente.Trim() == "");
        //Menú opciones (1.)
        int opciones1;
        double precioBase;
        int urgente;
        double extras = 0;
        int accesorio;
        bool tieneAccesorio1 = false;
        bool tieneAccesorio2 = false;
        bool tieneAccesorio3 = false;
        int cantidadAccesorio1 = 0;
        int cantidadAccesorio2 = 0;
        int cantidadAccesorio3 = 0;
        string telefono = "";

        do
        {
            Console.WriteLine();
            Console.WriteLine("Menú de opciones");
            Console.WriteLine();
            Console.WriteLine("1. Cambiar pantalla: 60€");
            Console.WriteLine("2. Cambiar batería: 40€");
            Console.WriteLine("3. Limpieza y revision general: 25€");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion");
            opciones1 = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            if (opciones1 < 1 || opciones1 > 3)
            {
                Console.WriteLine("Elige una opcion (numero) entre 1 y 3");
            }

        } while (opciones1 < 1 || opciones1 > 3);

        if (opciones1 == 1)
        {
            precioBase = 60;

        }
        else if (opciones1 == 2)
        {
            precioBase = 40;

        }
        else
        {
            precioBase = 25;
        }

        do
        {
            Console.WriteLine("1. Reparación urgente (en el día) +15€ ");
            Console.WriteLine("0. Reparación normal");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion");
            urgente = int.Parse(Console.ReadLine()!);

            if (urgente < 0 || urgente > 1)
            {
                Console.WriteLine("Elige una opcion (numero) entre 0 y 1");

            }

            else if (urgente == 1)
            {
                extras += 15;
                do
                {
                    Console.WriteLine("Añade teléfono de contacto");
                    telefono = Console.ReadLine() ?? "";
                    if (telefono.Trim() == "")
                    {
                        Console.WriteLine("El telefono de contacto no puede estar vacío");
                    }
                } while (telefono.Trim() == "");
            }

        } while (urgente < 0 || urgente > 1);
        do
        {
            Console.WriteLine("1. Añadir protector de panatalla +8€ ");
            Console.WriteLine("2. Añadir copia de seguridad de los datos +10€ ");
            Console.WriteLine("3. Añadir Funda +12€ ");
            Console.WriteLine("0. No añadir nada más +0€ ");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion");
            accesorio = int.Parse(Console.ReadLine()!);

            if (accesorio < 0 || accesorio > 3)
            {
                Console.WriteLine("Elige una opcion (numero) entre 0 y 3");
            }
            else if (accesorio == 1)
            {
                tieneAccesorio1 = true;
                cantidadAccesorio1 += 1;
                Console.WriteLine("Producto añadido");
            }
            else if (accesorio == 2)
            {
                tieneAccesorio2 = true;
                cantidadAccesorio2 += 1;
                Console.WriteLine("Producto añadido");
            }
            else if (accesorio == 3)
            {
                tieneAccesorio3 = true;
                cantidadAccesorio3 += 1;
                Console.WriteLine("Producto añadido");
            }

        } while (accesorio != 0);


        //importe y descuento 

        double subtotal = precioBase + extras + (cantidadAccesorio1 * 8) + (cantidadAccesorio2 * 10) + (cantidadAccesorio3 * 12);
        double descuento = 0;
        Console.WriteLine();
        Console.WriteLine("Subtotal: " + subtotal.ToString("F2") + "€");
        if (subtotal >= 100)
        {
            descuento = subtotal / 10;
        }
        Console.WriteLine("Descuento: " + descuento.ToString("F2") + "€");


        //Cobro

        decimal total = (decimal)(subtotal - descuento);
        decimal importeEntregado;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Total a pagar: " + total.ToString("F2") + "€");
            importeEntregado = Convert.ToDecimal(Console.ReadLine());

            if (importeEntregado < total)
            {
                Console.WriteLine("Importe insuficiente.Introduzca el importe de nuevo");
            }
        } while (importeEntregado < total);

        decimal cambio = importeEntregado - total;
        Console.WriteLine("Cambio: " + cambio.ToString("F2") + "€");


        //caja

        pedidosRealizados++;
        recaudacion += total;

        if (pedidosRealizados == 1 || pedidoMasCaro < total)
        {
            pedidoMasCaro = total;
            clientePedidoMasCaro = nombreCliente;
        }


        //ticket

        Console.WriteLine();
        Console.WriteLine("===================");
        Console.WriteLine(" Reparaciones RAW");
        Console.WriteLine("===================");
        Console.WriteLine();
        Console.WriteLine("Pedido número: " + pedidosRealizados);
        Console.WriteLine("Cliente: " + nombreCliente);
        switch (opciones1)
        {
            case (1):
                Console.WriteLine("Opcion: Cambiar pantalla: 60€");
                break;
            case (2):
                Console.WriteLine("Opcion: Cambiar bateria: 40€");
                break;
            case (3):
                Console.WriteLine("Opcion: Limpieza y revision general: 25€");
                break;
        }
        ;
        if (urgente == 1)
        {
            Console.WriteLine("Pedido urgente: +15€");
            Console.WriteLine("Numero de telefono: " + telefono);
        }
        if (tieneAccesorio1)
        {
            for (int i = 0; i < cantidadAccesorio1; i++)
            {
                Console.WriteLine("Protector de pantalla +8€");
            }
        }
        if (tieneAccesorio2)
        {
            for (int i = 0; i < cantidadAccesorio2; i++)
            {
                Console.WriteLine("Copia de seguridad +10€");
            }
        }
        if (tieneAccesorio3)
        {
            for (int i = 0; i < cantidadAccesorio3; i++)
            {
                Console.WriteLine("Funda +12€");
            }
        }
    }
    else if (opcionPrincipal == 2)
    {
        //Caja del día

        Console.WriteLine();
        Console.WriteLine("=================");
        Console.WriteLine("  Caja del día");
        Console.WriteLine("=================");

        if (pedidosRealizados == 0)
        {
            Console.WriteLine("Todavia no se han realizado pedidos");
        }
        else
        {

            decimal importeMedio = recaudacion / pedidosRealizados;

            Console.WriteLine("Pedidos realizados: " + pedidosRealizados);
            Console.WriteLine("Recaudacion: " + recaudacion.ToString("F2") + "€");
            Console.WriteLine("Importe medio: " + importeMedio.ToString("F2") + "€");
            Console.WriteLine("Pedido más caro: " + pedidoMasCaro.ToString("F2") + "€");
            Console.WriteLine("Cliente del pedido más caro: " + clientePedidoMasCaro);
        }

    }
    else if (opcionPrincipal == 0)
    {
        Console.WriteLine();
        Console.WriteLine("Cerrando Reparaciones RAW...");
        Console.WriteLine("Pedidos realizados: " + pedidosRealizados);
        Console.WriteLine("Recaudacion final: " + recaudacion.ToString("F2"));
        Console.WriteLine("Hasta pronto.");

    }
    else
    {
        Console.WriteLine("Opcion incorrecta. Seleciona 1, 2 o 0");
    }
} while (opcionPrincipal != 0);