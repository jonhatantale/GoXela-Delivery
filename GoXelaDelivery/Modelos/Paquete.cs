using System;

abstract class Paquete
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

	private string descripcion;

	public string Descripcion
	{
		get { return descripcion; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                descripcion = value;
            else
                descripcion = "Sin descripción";
        }
	}
	private double peso;

	public double Peso
	{
		get { return peso; }
        set
        {
            if (value > 0)
                peso = value;
            else
                peso = 0;
        }
	}

	private double valorDeclarado;

	public double ValorDeclarado
	{
		get { return valorDeclarado; }
        set
        {
            if (value >= 0)
                valorDeclarado = value;
            else
                valorDeclarado = 0;
        }
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

    private bool asignado;
    public bool Asignado
    {
        get { return asignado; }
        set { asignado = value; }
    }

    private EstadoPaquete estado;
    public EstadoPaquete Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    protected Paquete(int codigoCons, string descripcionCons, double pesoCons, double valorCons, string origenCons, string destinoCons)
    {
        Codigo = codigoCons;
        Descripcion = descripcionCons;
        Peso = pesoCons;
        ValorDeclarado = valorCons;
        DireccionOrigen = origenCons;
        DireccionDestino = destinoCons;
    }

    protected Paquete(int codigoCons, string descripcionCons, double pesoCons)
        : this(codigoCons, descripcionCons, pesoCons, 0, "", "")
    {
    }

    public double GetPeso()
    {
        return Peso;
    }

    public bool EstaAsignado()
    {
        return Asignado;
    }

    public abstract double CalcularTarifa(double distancia, string tipoServicio);
    public abstract bool RequiereCondicionEspecial();

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Código: {Codigo}, Descripción: {Descripcion}, Peso: {Peso}kg");
    }


}