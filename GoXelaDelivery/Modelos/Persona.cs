using System;

abstract class Persona 
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

	private string nombreCompleto;

	public string NombreCompleto
	{
		get { return nombreCompleto; }
		set
		{
            if (!string.IsNullOrWhiteSpace(value))
                nombreCompleto = value;
            else
                nombreCompleto = "Sin nombre";
        }
	}

	private int telefono;

	public int Telefono
	{
		get { return telefono; }
		set 
		{
            if (value > 0)
                telefono = value;
            else
                telefono = 0;
        }
	}
 
    protected Persona(int CodigoCons, string NombreCons, int TelefonoCons)
    {
        Codigo = CodigoCons;
        NombreCompleto = NombreCons;
        Telefono = TelefonoCons;
    }

    public virtual void MostrarInformacion()
	{
        Console.WriteLine($"Código: {Codigo}, Nombre: {NombreCompleto}, Teléfono: {Telefono}");
    }



}