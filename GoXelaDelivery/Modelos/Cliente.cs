using System;

class Cliente : Persona
{
    private string correo;
    public string Correo
    {
        get { return correo; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                correo = value;
            else
                correo = "Sin correo";
        }
    }

    private string direccion;
    public string Direccion
    {
        get { return direccion; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                direccion = value;
            else
                direccion = "Sin dirección";
        }
    }

    private int cantidadSolicitudes;
    public int CantidadSolicitudes
    {
        get { return cantidadSolicitudes; }
        set
        {
            if (value >= 0)
                cantidadSolicitudes = value;
            else
                cantidadSolicitudes = 0;
        }
    }

    public Cliente(int codigo, string nombre, int telefono, string correoCons, string direccionCons)
        : base(codigo, nombre, telefono)
    {
        Correo = correoCons;
        Direccion = direccionCons;
        CantidadSolicitudes = 0;
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Correo: {Correo}, Dirección: {Direccion}, Solicitudes: {CantidadSolicitudes}");
    }
}