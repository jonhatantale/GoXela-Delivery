using System;
using System.Collections.Generic;

class GestorEntregas
{
    private List<Entrega> entregas = new List<Entrega>();
    private int contadorCodigo = 1;

    private GestorClientes gestorClientes;
    private GestorVehiculos gestorVehiculos;
    private GestorRepartidores gestorRepartidores;
    private GestorPaquetes gestorPaquetes;
    private GestorIncidencias gestorIncidencias;

    public List<Entrega> Entregas
    {
        get { return entregas; }
    }

    public GestorEntregas(GestorClientes gc, GestorVehiculos gv, GestorRepartidores gr, GestorPaquetes gp, GestorIncidencias gi)
    {
        gestorClientes = gc;
        gestorVehiculos = gv;
        gestorRepartidores = gr;
        gestorPaquetes = gp;
        gestorIncidencias = gi;
    }

    public void RegistrarEntrega(int codigoCliente, int codigoPaquete, int codigoRepartidor, int codigoVehiculo, string fecha, string origen, string destino, double distancia, string tipoServicio)
    {
        Cliente cliente = gestorClientes.ObtenerClientePorCodigo(codigoCliente);
        if (cliente == null)
        {
            Console.WriteLine("Error: Cliente no encontrado");
            return;
        }

        Paquete paquete = gestorPaquetes.ObtenerPaquetePorCodigo(codigoPaquete);
        if (paquete == null)
        {
            Console.WriteLine("Error: Paquete no encontrado");
            return;
        }

        Repartidor repartidor = gestorRepartidores.ObtenerRepartidorPorCodigo(codigoRepartidor);
        if (repartidor == null)
        {
            Console.WriteLine("Error: Repartidor no encontrado");
            return;
        }

        Vehiculo vehiculo = gestorVehiculos.ObtenerVehiculoPorCodigo(codigoVehiculo);
        if (vehiculo == null)
        {
            Console.WriteLine("Error: Vehículo no encontrado");
            return;
        }

        if (!vehiculo.PuedeTransportar(paquete))
        {
            Console.WriteLine("Error: El vehículo no puede transportar este paquete");
            return;
        }

        Entrega nuevaEntrega = new Entrega(contadorCodigo, cliente, paquete, repartidor, vehiculo, fecha, origen, destino, distancia, tipoServicio);
        nuevaEntrega.CalcularTarifa();
        entregas.Add(nuevaEntrega);
        Console.WriteLine($"Entrega registrada con código {contadorCodigo}. Total: Q{nuevaEntrega.Total}");
        contadorCodigo++;
    }

    public Entrega ConsultarEntrega(int codigo)
    {
        foreach (var e in entregas)
        {
            if (e.Codigo == codigo)
            {
                e.MostrarInformacion();
                return e;
            }
        }
        Console.WriteLine("Entrega no encontrada");
        return null;
    }

    public void ListarEntregas()
    {
        if (entregas.Count == 0)
        {
            Console.WriteLine("No hay entregas registradas");
            return;
        }

        foreach (var e in entregas)
        {
            e.MostrarInformacion();
            Console.WriteLine("---");
        }
    }

    public void CambiarEstadoEntrega(int codigo, string nuevoEstado)
    {
        foreach (var e in entregas)
        {
            if (e.Codigo == codigo)
            {
                e.CambiarEstado(nuevoEstado);
                Console.WriteLine($"Estado de entrega {codigo} cambiado a {nuevoEstado}");
                return;
            }
        }
        Console.WriteLine("Entrega no encontrada");
    }

    public int ContarEntregasRecursivo(int index = 0)
    {
        if (index >= entregas.Count)
            return 0;
        return 1 + ContarEntregasRecursivo(index + 1);
    }

    public Entrega ObtenerEntregaPorCodigo(int codigo)
    {
        foreach (var e in entregas)
        {
            if (e.Codigo == codigo)
                return e;
        }
        return null;
    }

    public unsafe void CompararEntregas(int codigo1, int codigo2)
    {
        Entrega e1 = ObtenerEntregaPorCodigo(codigo1);
        Entrega e2 = ObtenerEntregaPorCodigo(codigo2);

        if (e1 == null || e2 == null)
        {
            Console.WriteLine("Una o ambas entregas no existen");
            return;
        }

        fixed (char* p1 = e1.Estado, p2 = e2.Estado)
        {
            Console.WriteLine($"Entrega 1 estado: {new string(p1)}");
            Console.WriteLine($"Entrega 2 estado: {new string(p2)}");
        }
    }
}