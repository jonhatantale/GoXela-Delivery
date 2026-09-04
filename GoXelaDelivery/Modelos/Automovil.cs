using System;

class Automovil : Vehiculo
{

    private bool tieneRefrigeracion;

    public bool TieneRefrigeracion
    {
        get { return tieneRefrigeracion; }
        set { tieneRefrigeracion = value; }
    }

    public Automovil(int codigo, string placa, string marca, string modelo, int capacidad, double costoBase, bool tieneFrio)
        : base(codigo, placa, marca, modelo, capacidad, costoBase)
    {
        TieneRefrigeracion = tieneFrio;
    }

    public override bool PuedeTransportar(Paquete paquete)
    {
        return paquete.Peso <= CapacidadMaxima;
    }

    public override double CalcularCostoOperativo()
    {
        double costo = CostoOperativoBase * 2;
        if (TieneRefrigeracion)
            costo += 50;
        return costo;
    }
}