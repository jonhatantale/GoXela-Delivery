using System;

struct Direccion
{
    public string Calle;
    public string Zona;
    public string Referencia;

    public Direccion(string calleParam, string zonaParam, string referenciaParam)
    {
        Calle = calleParam;
        Zona = zonaParam;
        Referencia = referenciaParam;
    }

    public void MostrarDireccion()
    {
        Console.WriteLine($"Calle: {Calle}, Zona: {Zona}, Ref: {Referencia}");
    }
}