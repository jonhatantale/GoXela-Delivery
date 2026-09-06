class ProductoRefrigerado: Paquete
{
	private double temperaturaMaxima;

	public double TemperaturaMaxima
	{
		get { return temperaturaMaxima; }
		set { temperaturaMaxima = value; }
	}
	private double temperaturaMinima;

	public double TemperaturaMinima
	{
		get { return temperaturaMinima; }
		set { temperaturaMinima = value; }
	}
    public ProductoRefrigerado(int codigoCons, string descripcionCons, double pesoCons, double valorCons, string origenCons, string destinoCons, double tempMaxCons, double tempMinCons)
       : base(codigoCons, descripcionCons, pesoCons, valorCons, origenCons, destinoCons)
    {
        TemperaturaMaxima = tempMaxCons;
        TemperaturaMinima = tempMinCons;
    }
	public override double CalcularTarifa(double distancia, string tipoServicio)
	{
		double tarifaBase = distancia;
		double recargoRefrigerado = tarifaBase * 0.20;
		double recargoServicio = UtilidadesTarifa.RecargoPorServicio(tipoServicio);
		return (tarifaBase + recargoRefrigerado) * (1 + recargoServicio);
    }
    public override bool RequiereCondicionEspecial	()
    {
        return true;
    }
}