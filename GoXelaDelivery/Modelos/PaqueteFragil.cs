class PaqueteFragil: Paquete
{
	private bool tratoEspecial;

	public bool TratoEspecial
	{
		get { return tratoEspecial; }
		set { tratoEspecial = value; }
	}
    public PaqueteFragil(int codigoCons, string descripcionCons, double pesoCons, double valorCons, string origenCons, string destinoCons)
       : base(codigoCons, descripcionCons, pesoCons, valorCons, origenCons, destinoCons)
    {
        TratoEspecial = true;
    }
    public PaqueteFragil(int codigoCons, string descripcionCons, double pesoCons)
       : base(codigoCons, descripcionCons, pesoCons)
    {
        TratoEspecial = true;
    }
    public override double CalcularTarifa(double distancia, string tipoServicio)
    {
        double tarifaBase = distancia;
        double recargoFijo = 15.00;
        double recargoServicio = UtilidadesTarifa.RecargoPorServicio(tipoServicio);
        return (tarifaBase + recargoFijo) * (1 + recargoServicio);
    }
    public override bool RequiereCondicionEspecial()
    {
        return TratoEspecial;
    }
}