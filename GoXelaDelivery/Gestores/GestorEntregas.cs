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
}