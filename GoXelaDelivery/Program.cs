using System;

class Program
{
    static GestorClientes gestorClientes = new GestorClientes();
    static GestorRepartidores gestorRepartidores = new GestorRepartidores();
    static GestorVehiculos gestorVehiculos = new GestorVehiculos();
    static GestorPaquetes gestorPaquetes = new GestorPaquetes();
    static GestorEntregas gestorEntregas = new GestorEntregas(gestorClientes, gestorVehiculos, gestorRepartidores, gestorPaquetes, null);
    static GestorIncidencias gestorIncidencias = new GestorIncidencias();
    static GestorReportes gestorReportes = new GestorReportes(gestorEntregas, gestorRepartidores, gestorVehiculos, gestorPaquetes);

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
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n--- Gestión de Clientes ---");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Consultar cliente");
            Console.WriteLine("3. Listar clientes");
            Console.WriteLine("4. Actualizar cliente");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    int telefono = int.Parse(Console.ReadLine());
                    Console.Write("Correo: ");
                    string correo = Console.ReadLine();
                    Console.Write("Dirección: ");
                    string direccion = Console.ReadLine();
                    gestorClientes.RegistrarCliente(nombre, telefono, correo, direccion);
                    break;

                case 2:
                    Console.Write("Código del cliente: ");
                    int codigo = int.Parse(Console.ReadLine());
                    gestorClientes.ConsultarCliente(codigo);
                    break;

                case 3:
                    gestorClientes.ListarClientes();
                    break;

                case 4:
                    Console.Write("Código del cliente: ");
                    int codActualizar = int.Parse(Console.ReadLine());
                    Console.Write("Nuevo correo: ");
                    string nuevoCorreo = Console.ReadLine();
                    Console.Write("Nueva dirección: ");
                    string nuevaDireccion = Console.ReadLine();
                    gestorClientes.ActualizarCliente(codActualizar, nuevoCorreo, nuevaDireccion);
                    break;

                case 0:
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
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
        int op = int.Parse(Console.ReadLine());

        bool volver = false;
        while (!volver)
        {
            switch (op)
            {
                case 1:
                    Console.WriteLine("Tipo: 1=Bicicleta, 2=Motocicleta, 3=Automóvil");
                    Console.Write("Tipo: ");
                    int tipo = int.Parse(Console.ReadLine());
                    Console.Write("Placa (o vacío si es bicicleta): ");
                    string placa = Console.ReadLine();
                    Console.Write("Marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Capacidad (kg): ");
                    int capacidad = int.Parse(Console.ReadLine());
                    Console.Write("Costo operativo base: ");
                    double costo = double.Parse(Console.ReadLine());

                    bool tieneRefri = false;
                    if (tipo == 3)
                    {
                        Console.Write("¿Tiene refrigeración? (s/n): ");
                        tieneRefri = Console.ReadLine().ToLower() == "s";
                    }

                    gestorVehiculos.RegistrarVehiculo(tipo, placa, marca, modelo, capacidad, costo, tieneRefri);
                    break;
                case 2:
                    Console.Write("Código del vehículo: ");
                    int codigoVeh = int.Parse(Console.ReadLine());
                    gestorVehiculos.ConsultarVehiculo(codigoVeh);
                    break;
                case 3:
                    gestorVehiculos.ListarVehiculos();
                    break;
                case 4:
                    Console.Write("Código del vehículo: ");
                    int codCambiar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nuevo estado: Disponible, Asignado, EnMantenimiento");
                    Console.Write("Estado: ");
                    string estadoStr = Console.ReadLine();
                    if (Enum.TryParse(estadoStr, out EstadoVehiculo nuevoEstado))
                        gestorVehiculos.CambiarEstadoVehiculo(codCambiar, nuevoEstado);
                    else
                        Console.WriteLine("Estado inválido");
                    break;
                case 0:
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
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
        int op = int.Parse(Console.ReadLine());

        bool volver = false;
        while (!volver)
        {
            switch (op)
            {
                case 1:
                    Console.Write("Código cliente: ");
                    int codCliente = int.Parse(Console.ReadLine());
                    Console.Write("Código paquete: ");
                    int codPaquete = int.Parse(Console.ReadLine());
                    Console.Write("Código repartidor: ");
                    int codRepartidor = int.Parse(Console.ReadLine());
                    Console.Write("Código vehículo: ");
                    int codVehiculo = int.Parse(Console.ReadLine());
                    Console.Write("Fecha (dd/mm/yyyy): ");
                    string fecha = Console.ReadLine();
                    Console.Write("Dirección origen: ");
                    string origen = Console.ReadLine();
                    Console.Write("Dirección destino: ");
                    string destino = Console.ReadLine();
                    Console.Write("Distancia (km): ");
                    double distancia = double.Parse(Console.ReadLine());
                    Console.WriteLine("Tipo: Normal, Prioritario, Urgente");
                    Console.Write("Tipo de servicio: ");
                    string tipoServicio = Console.ReadLine();

                    gestorEntregas.RegistrarEntrega(codCliente, codPaquete, codRepartidor, codVehiculo, fecha, origen, destino, distancia, tipoServicio);
                    break;

                case 2:
                    Console.Write("Código de entrega: ");
                    int codEnt = int.Parse(Console.ReadLine());
                    gestorEntregas.ConsultarEntrega(codEnt);
                    break;

                case 3:
                    gestorEntregas.ListarEntregas();
                    break;

                case 4:
                    Console.Write("Código de entrega: ");
                    int codCambiarEnt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Estados: Solicitada, Asignada, Recogida, EnRuta, Entregada, Cancelada, Reprogramada");
                    Console.Write("Nuevo estado: ");
                    string nuevoEstado = Console.ReadLine();
                    gestorEntregas.CambiarEstadoEntrega(codCambiarEnt, nuevoEstado);
                    break;

                case 0:
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }


    static void MenuIncidencias()
    {
        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n--- Gestión de Incidencias ---");
            Console.WriteLine("1. Registrar incidencia");
            Console.WriteLine("2. Consultar incidencia");
            Console.WriteLine("3. Listar incidencias");
            Console.WriteLine("4. Actualizar estado");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Write("Tipo de incidencia: ");
                    string tipo = Console.ReadLine();
                    Console.Write("Descripción: ");
                    string descripcion = Console.ReadLine();
                    Console.Write("Fecha (dd/mm/yyyy): ");
                    string fechaInc = Console.ReadLine();

                    gestorIncidencias.RegistrarIncidencia(tipo, descripcion, DateTime.Parse(fechaInc));
                    break;

                case 2:
                    Console.Write("Código de incidencia: ");
                    int codInc = int.Parse(Console.ReadLine());
                    gestorIncidencias.ConsultarIncidencia(codInc);
                    break;

                case 3:
                    gestorIncidencias.ListarIncidencias();
                    break;

                case 4:
                    Console.Write("Código de incidencia: ");
                    int codActInc = int.Parse(Console.ReadLine());
                    gestorIncidencias.ActualizarEstadoIncidencia(codActInc);
                    break;

                case 0:
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
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