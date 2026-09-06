using System;
using System.Collections.Generic;

class Entrega
{
    private int codigo;
    public int Codigo
    {
        get { return codigo; }
        set
        {
            if (value > 0)
                codigo = value;
            else
                codigo = 0;
        }
    }

    private Cliente cliente;
    public Cliente Cliente
    {
        get { return cliente; }
        set { cliente = value; }
    }

    private Paquete paquete;
    public Paquete Paquete
    {
        get { return paquete; }
        set { paquete = value; }
    }

    private Repartidor repartidor;
    public Repartidor Repartidor
    {
        get { return repartidor; }
        set { repartidor = value; }
    }

    private Vehiculo vehiculo;
    public Vehiculo Vehiculo
    {
        get { return vehiculo; }
        set { vehiculo = value; }
    }

    private string fechaSolicitud;
    public string FechaSolicitud
    {
        get { return fechaSolicitud; }
        set { fechaSolicitud = value; }
    }

    private string direccionOrigen;
    public string DireccionOrigen
    {
        get { return direccionOrigen; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                direccionOrigen = value;
            else
                direccionOrigen = "Sin dirección";
        }
    }

    private string direccionDestino;
    public string DireccionDestino
    {
        get { return direccionDestino; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                direccionDestino = value;
            else
                direccionDestino = "Sin dirección";
        }
    }

    private double distanciaEstimada;
    public double DistanciaEstimada
    {
        get { return distanciaEstimada; }
        set
        {
            if (value > 0)
                distanciaEstimada = value;
            else
                distanciaEstimada = 0;
        }
    }

    private string tipoServicio;
    public string TipoServicio
    {
        get { return tipoServicio; }
        set { tipoServicio = value; }
    }

    private string estado;
    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    private double tarifaBase;
    public double TarifaBase
    {
        get { return tarifaBase; }
        set
        {
            if (value >= 0)
                tarifaBase = value;
            else
                tarifaBase = 0;
        }
    }

    private double recargos;
    public double Recargos
    {
        get { return recargos; }
        set
        {
            if (value >= 0)
                recargos = value;
            else
                recargos = 0;
        }
    }

    private double descuentos;
    public double Descuentos
    {
        get { return descuentos; }
        set
        {
            if (value >= 0)
                descuentos = value;
            else
                descuentos = 0;
        }
    }

    private double total;
    public double Total
    {
        get { return total; }
        set
        {
            if (value >= 0)
                total = value;
            else
                total = 0;
        }
    }

    private List<Incidencias> incidencia = new List<Incidencias>();
    public List<Incidencias> Incidencia
    {
        get { return incidencia; }
    }

    public Entrega(int codigo1, Cliente cliente1, Paquete paquete1, Repartidor repartidor1, Vehiculo vehiculo1, string fecha1, string origen1, string destino1, double distancia1, string tipo1)
    {
        Codigo = codigo1;
        Cliente = cliente1;
        Paquete = paquete1;
        Repartidor = repartidor1;
        Vehiculo = vehiculo1;
        FechaSolicitud = fecha1;
        DireccionOrigen = origen1;
        DireccionDestino = destino1;
        DistanciaEstimada = distancia1;
        TipoServicio = tipo1;
        Estado = "Solicitada";
        TarifaBase = 0;
        Recargos = 0;
        Descuentos = 0;
        Total = 0;
    }

    public void CalcularTarifa()
    {
        if (Paquete != null && Vehiculo != null)
        {
            TarifaBase = Paquete.CalcularTarifa(DistanciaEstimada, TipoServicio);
            Total = TarifaBase + Recargos - Descuentos;
            if (Total < 0)
                Total = 0;
        }
    }

    public void CambiarEstado(string nuevoEstado)
    {
        Estado = nuevoEstado;
    }

    public void AgregarIncidencia(Incidencias incidencia)
    {
        if (incidencia != null)
            Incidencias.Add(incidencia);
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Entrega {Codigo}: {Estado}");
        Console.WriteLine($"Cliente: {Cliente.NombreCompleto}");
        Console.WriteLine($"De: {DireccionOrigen} a {DireccionDestino}");
        Console.WriteLine($"Distancia: {DistanciaEstimada}km");
        Console.WriteLine($"Total: Q{Total}");
        Console.WriteLine($"Incidencias: {Incidencias.Count}");
    }
}