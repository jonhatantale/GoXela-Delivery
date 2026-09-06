using System;

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

}