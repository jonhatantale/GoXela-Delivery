using System;

class Program
{
    static GestorClientes gestorClientes = new GestorClientes();
    static GestorRepartidores gestorRepartidores = new GestorRepartidores();
    static GestorVehiculos gestorVehiculos = new GestorVehiculos();
    static GestorPaquetes gestorPaquetes = new GestorPaquetes();
    static GestorEntregas gestorEntregas = new GestorEntregas(gestorClientes, gestorVehiculos, gestorRepartidores, gestorPaquetes, null);
    static GestorIncidencias gestorIncidencias = new GestorIncidencias();
    static GestorReportes gestorReportes = new GestorReportes();

    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n========== GOXELA DELIVERY ==========");
            Console.WriteLine("1. Gestión de clientes");
            Console.WriteLine("2. Gestión de repartidores");
            Console.WriteLine("3. Gestión de vehículos");
            Console.WriteLine("4. Gestión de paquetes");
            Console.WriteLine("5. Gestión de entregas");
            Console.WriteLine("6. Gestión de incidencias");
            Console.WriteLine("7. Reportes");
            Console.WriteLine("8. Salir");
            Console.WriteLine("====================================");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuClientes();
                    break;
                case "2":
                    MenuRepartidores();
                    break;
                case "3":
                    MenuVehiculos();
                    break;
                case "4":
                    MenuPaquetes();
                    break;
                case "5":
                    MenuEntregas();
                    break;
                case "6":
                    MenuIncidencias();
                    break;
                case "7":
                    MenuReportes();
                    break;
                case "8":
                    salir = true;
                    Console.WriteLine("Gracias por usar GoXela Delivery");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }

    static void MenuClientes()
    {
        Console.WriteLine("\n--- Gestión de Clientes ---");
        Console.WriteLine("1. Registrar cliente");
        Console.WriteLine("2. Consultar cliente");
        Console.WriteLine("3. Listar clientes");
        Console.WriteLine("4. Actualizar cliente");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                // TODO: Registrar cliente
                break;
            case "2":
                // TODO: Consultar cliente
                break;
            case "3":
                gestorClientes.ListarClientes();
                break;
            case "4":
                // TODO: Actualizar cliente
                break;
        }
    }

    static void MenuRepartidores()
    {
        Console.WriteLine("\n--- Gestión de Repartidores ---");
        Console.WriteLine("1. Registrar repartidor");
        Console.WriteLine("2. Consultar repartidor");
        Console.WriteLine("3. Listar repartidores");
        Console.WriteLine("4. Cambiar estado");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                // TODO
                break;
            case "2":
                // TODO
                break;
            case "3":
                gestorRepartidores.ListarRepartidores();
                break;
            case "4":
                // TODO
                break;
        }
    }

    static void MenuVehiculos()
    {
        Console.WriteLine("\n--- Gestión de Vehículos ---");
        Console.WriteLine("1. Registrar vehículo");
        Console.WriteLine("2. Consultar vehículo");
        Console.WriteLine("3. Listar vehículos");
        Console.WriteLine("4. Cambiar estado");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                // TODO
                break;
            case "2":
                // TODO
                break;
            case "3":
                gestorVehiculos.ListarVehiculos();
                break;
            case "4":
                // TODO
                break;
        }
    }

    static void MenuPaquetes()
    {
        Console.WriteLine("\n--- Gestión de Paquetes ---");
        Console.WriteLine("1. Registrar paquete");
        Console.WriteLine("2. Consultar paquete");
        Console.WriteLine("3. Listar paquetes");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                // TODO
                break;
            case "2":
                // TODO
                break;
            case "3":
                gestorPaquetes.ListarPaquetes();
                break;
        }
    }

    static void MenuEntregas()
    {
        Console.WriteLine("\n--- Gestión de Entregas ---");
        Console.WriteLine("1. Registrar entrega");
        Console.WriteLine("2. Consultar entrega");
        Console.WriteLine("3. Listar entregas");
        Console.WriteLine("4. Cambiar estado");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                // TODO
                break;
            case "2":
                // TODO
                break;
            case "3":
                gestorEntregas.ListarEntregas();
                break;
            case "4":
                // TODO
                break;
        }
    }

    static void MenuIncidencias()
    {
        Console.WriteLine("\n--- Gestión de Incidencias ---");
        Console.WriteLine("1. Registrar incidencia");
        Console.WriteLine("2. Consultar incidencia");
        Console.WriteLine("3. Listar incidencias");
        Console.WriteLine("4. Actualizar estado");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                // TODO
                break;
            case "2":
                // TODO
                break;
            case "3":
                gestorIncidencias.ListarIncidencias();
                break;
            case "4":
                // TODO
                break;
        }
    }

    static void MenuReportes()
    {
        Console.WriteLine("\n--- Reportes ---");
        Console.WriteLine("1. Entregas activas");
        Console.WriteLine("2. Entregas finalizadas");
        Console.WriteLine("3. Entregas canceladas");
        Console.WriteLine("4. Entregas con incidencias");
        Console.WriteLine("5. Repartidores disponibles");
        Console.WriteLine("6. Repartidor con más entregas");
        Console.WriteLine("7. Vehículo más utilizado");
        Console.WriteLine("8. Cantidad de paquetes por tipo");
        Console.WriteLine("9. Total de ingresos");
        Console.WriteLine("10. Entrega con mayor costo");
        Console.WriteLine("0. Volver");
        Console.Write("Opción: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1":
                gestorReportes.ReporteEntregasActivas();
                break;
            case "2":
                gestorReportes.ReporteEntregasFinalizadas();
                break;
                //Completar los demás casos
        }
    }
}