using System;

class Bicicleta : Vehiculo
{
    public Bicicleta(int codigo, string marca, string modelo, int capacidad, double costoBase)
        : base(codigo, "", marca, modelo, capacidad, costoBase)
    {
    }

    public override bool PuedeTransportar(Paquete paquete)
    {
        return paquete.Peso <= CapacidadMaxima;
    }

    public override double CalcularCostoOperativo()
    {
        return CostoOperativoBase;
    }
}