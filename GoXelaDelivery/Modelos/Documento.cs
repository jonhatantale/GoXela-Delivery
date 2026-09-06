class Documento : Paquete
{
    public Documento(int codigoCons, string descripcionCons, double pesoCons, double valorCons, string origenCons, string destinoCons)
        : base(codigoCons, descripcionCons, pesoCons, valorCons, origenCons, destinoCons)
    {

    }
    public Documento(int codigoCons, string descripcionCons, double pesoCons)
       : base(codigoCons, descripcionCons, pesoCons)
    {
    }
    public override double CalcularTarifa(double distancia, string tipoServicio)
    {
        double tarifaBase = distancia;
        double recargoServicio = UtilidadesTarifa.RecargoPorServicio(tipoServicio);
        return tarifaBase * (1 + recargoServicio);
    }
    public override bool RequiereCondicionEspecial()
    {
        return false;
    }
}