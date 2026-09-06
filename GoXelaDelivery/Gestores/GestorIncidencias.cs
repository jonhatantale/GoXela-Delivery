using System;
using System.Collections.Generic;

class GestorIncidencias
{
    private List<Incidencia> incidencias = new List<Incidencia>();
    public List<Incidencia> Incidencias
    {
        get { return incidencias; }
    }

    private int contadorCodigo = 1;

    public void RegistrarIncidencia(string tipo, string descripcion, DateTime fecha)
    {
        if (string.IsNullOrWhiteSpace(tipo))
        {
            Console.WriteLine("Error: El tipo no puede estar vacío");
            return;
        }

        if (string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("Error: La descripción no puede estar vacía");
            return;
        }

        Incidencia nuevaIncidencia = new Incidencia(contadorCodigo, tipo, descripcion, fecha);
        incidencias.Add(nuevaIncidencia);
        Console.WriteLine($"Incidencia registrada exitosamente con código {contadorCodigo}");
        contadorCodigo++;
    }

    public Incidencia ConsultarIncidencia(int codigo)
    {
        foreach (var i in incidencias)
        {
            if (i.Codigo == codigo)
            {
                i.MostrarInformacion();
                return i;
            }
        }
        Console.WriteLine("Incidencia no encontrada");
        return null;
    }

    public void ListarIncidencias()
    {
        if (incidencias.Count == 0)
        {
            Console.WriteLine("No hay incidencias registradas");
            return;
        }

        foreach (var i in incidencias)
        {
            i.MostrarInformacion();
            Console.WriteLine("---");
        }
    }

    public void ActualizarEstadoIncidencia(int codigo)
    {
        foreach (var i in incidencias)
        {
            if (i.Codigo == codigo)
            {
                i.CerrarIncidencia(); 
                Console.WriteLine($"Incidencia {codigo} cerrada");
                return;
            }
        }
        Console.WriteLine("Incidencia no encontrada");
    }

    public int ContarIncidencias()
    {
        return incidencias.Count;
    }

    public Incidencia ObtenerIncidenciaPorCodigo(int codigo)
    {
        foreach (var i in incidencias)
        {
            if (i.Codigo == codigo)
                return i;
        }
        return null;
    }
}