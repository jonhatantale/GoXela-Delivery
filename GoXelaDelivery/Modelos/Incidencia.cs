using System;
class Incidencia
{
	private int codigo;

	public int Codigo 
	{
		get { return codigo; }
		set 
		{
			if(value >0)
			{
                codigo = value;
            }
			else
			{
				codigo = 0;
			}
		}
	}
    private string tipo;

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }
    private string descripcion;

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    private DateTime fecha;

    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }
    private EstadoIncidencia estado;

    public EstadoIncidencia Estado
    {
        get { return estado; }
        set { estado = value; }
    }
    private string accionTomada;

    public string AccionTomada
    {
        get { return accionTomada; }
        set { accionTomada = value; }
    }
    public Incidencia(int codigoCons, string tipoCons, string descripcionCons, DateTime fechaCons)
    {
        Codigo = codigoCons;
        Tipo = tipoCons;
        Descripcion = descripcionCons;
        Fecha = fechaCons;
        Estado = EstadoIncidencia.Abierta;
        accionTomada = "Sin acción registrada";
    }
    public void RegistrarAccionTomada(string accion)
    {
        if (string.IsNullOrWhiteSpace(accion))
        {
            throw new CampoVacioException("La acción tomada no puede estar vacía");
        }

        AccionTomada = accion;
    }
    public void CerrarIncidencia()
    {
        if (Estado == EstadoIncidencia.Cerrada)
        {
            throw new OperacionNoPermitidaException("La incidencia ya se encuentra cerrada");
        }

        Estado = EstadoIncidencia.Cerrada;
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Código: {Codigo}, Tipo: {Tipo}, Descripción: {Descripcion}, Fecha: {Fecha:d}, Estado: {Estado}, Acción tomada: {AccionTomada}");
    }
}