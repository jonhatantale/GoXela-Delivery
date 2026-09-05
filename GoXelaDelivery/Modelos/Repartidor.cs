using System;

class Repartidor : Persona
{
	private int numeroLicencia;

	public int NumeroLicencia
	{
		get { return numeroLicencia; }
		set
		{
			if (value > 0)
			{
				numeroLicencia = value;
			}
			else
			{
				numeroLicencia = 0;
			}
		}
	}
	private string tipoLicencia;

	public string TipoLicencia
	{
		get { return tipoLicencia; }
		set
		{
			if (!string.IsNullOrWhiteSpace(value))
				tipoLicencia = value;
			else
				tipoLicencia = "Sin licencia";
		}
	}
	private EstadoRepartidor estado;

	public EstadoRepartidor Estado
	{
		get { return estado; }
		set { estado = value; }
	}
	private int cantidadEntregas;

	public int CantidadEntregas
	{
		get { return cantidadEntregas; }
		set { cantidadEntregas = value; }
	}
	private double calificacionPromedio;

	public double CalificacionPromedio
	{
		get { return calificacionPromedio; }
		set { calificacionPromedio = value; }
	}
	private object entregaActiva;

	public object EntregaActiva
	{
		get { return entregaActiva; }
		set { entregaActiva = value; }
	}
	public Repartidor(int codigoCons, string nombreCons, int telefonoCons, int licenciaCons, string tipoLicenciaCons)
		: base(codigoCons, nombreCons, telefonoCons)
	{
		NumeroLicencia = licenciaCons;
		TipoLicencia = tipoLicenciaCons;
		Estado = EstadoRepartidor.Disponible;
		CantidadEntregas = 0;
		calificacionPromedio = 0;
		entregaActiva = null;
	}
	public Repartidor(int codigoCons, string nombreCons, int telefonoCons)
		: this(codigoCons, nombreCons, telefonoCons, 0, "Sin licencia")
	{
	}
    public bool EstaDisponible()
    {
        return Estado == EstadoRepartidor.Disponible && entregaActiva == null;
    }
    public void AsignarEntrega(object entrega)
    {
        entregaActiva = entrega;
        Estado = EstadoRepartidor.Asignado;
    }
    public void LiberarEntrega()
    {
        entregaActiva = null;
        Estado = EstadoRepartidor.Disponible;
    }
    public bool PoseeLicenciaPara(string tipoVehiculo)
    {
        if (tipoVehiculo.Equals("Bicicleta", StringComparison.OrdinalIgnoreCase))
            return true;
        else if (tipoVehiculo.Equals("Motocicleta", StringComparison.OrdinalIgnoreCase))
            return TipoLicencia.Equals("A", StringComparison.OrdinalIgnoreCase);
        else if (tipoVehiculo.Equals("Automovil", StringComparison.OrdinalIgnoreCase) ||
                 tipoVehiculo.Equals("Automóvil", StringComparison.OrdinalIgnoreCase))
            return TipoLicencia.Equals("B", StringComparison.OrdinalIgnoreCase);
        else
            return false;
    }
	public void ActualizarCalificacion(double nuevaCalificacion)
    {
        if (nuevaCalificacion < 0 || nuevaCalificacion > 5)
        {
			return;
        }
        calificacionPromedio = ((calificacionPromedio * cantidadEntregas) + nuevaCalificacion) / (cantidadEntregas + 1);
    }
    public void IncrementarEntregas()
    {
        cantidadEntregas++;
    }
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Licencia: {NumeroLicencia} ({TipoLicencia}), Estado: {Estado}, Entregas: {CantidadEntregas}, Calificación: {CalificacionPromedio:F2}");
    }
}