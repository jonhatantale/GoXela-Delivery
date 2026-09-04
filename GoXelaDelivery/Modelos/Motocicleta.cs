using System;

class Motocicleta : Vehiculo
{
    public Motocicleta(int codigo, string placa, string marca, string modelo, int capacidad, double costoBase)
        : base(codigo, placa, marca, modelo, capacidad, costoBase)
    {
    }

    public override bool PuedeTransportar(Paquete paquete)
    {
        return paquete.Peso <= CapacidadMaxima;
    }

    public override double CalcularCostoOperativo()
    {
        return CostoOperativoBase * 1.5;    
    }
}