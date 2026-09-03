using System;

abstract class Vehiculo
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

	private string placa;

	public  string Placa
	{
		get { return placa; }
		set { placa = value; }
	}

	private string marca;

	public string Marca
	{
		get { return marca; }
		set
		{
            if (!string.IsNullOrWhiteSpace(value))
                marca = value;
            else
                marca = "Sin marca";
        }
	}

	private string modelo;

	public string Modelo
	{
		get { return modelo; }
		set
		{
            if (!string.IsNullOrWhiteSpace(value))
                modelo = value;
            else
                modelo = "Sin modelo";
        }
	}

	private int capacidadMaxima;

	public int CapacidadMaxima
	{
		get { return capacidadMaxima; }
		set
		{
            if (value > 0)
                capacidadMaxima = value;
            else
                capacidadMaxima = 1;
        }
	}

	private double costoOperativoBase;

	public double CostoOperativoBase
	{
		get { return costoOperativoBase; }
		set
		{
            if (value >= 0)
                costoOperativoBase = value;
            else
                costoOperativoBase = 0;
        }
	}

    private EstadoVehiculo estado;
    public EstadoVehiculo Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    protected Vehiculo(int CodigoCons, string PlacaCons, string MarcaCons, string ModeloCons, int CapacidadCons, double CostoCons)
    {
		Codigo = CodigoCons;
		Placa = PlacaCons;
		Marca = MarcaCons;
		Modelo = ModeloCons;
		CapacidadMaxima = CapacidadCons;
		CostoOperativoBase = CostoCons;
	}

    public bool EstaDisponible()
    {
        return Estado == EstadoVehiculo.Disponible;
    }

    public abstract bool PuedeTransportar(Paquete paquete);
    public abstract double CalcularCostoOperativo();

    public virtual void MostrarInformacion()
	{
        Console.WriteLine($"Código: {Codigo}, Placa: {Placa}, Marca: {Marca}, Modelo: {Modelo}");
    }

    public void CambiarEstado(EstadoVehiculo nuevoEstado)
    {
        Estado = nuevoEstado;
    }


}