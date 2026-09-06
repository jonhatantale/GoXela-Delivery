using System;
using System.Collections.Generic;

class GestorIncidencias
{
    private List<Incidencia> incidencias = new List<Incidencia>();
    private int contadorCodigo = 1;

    public void RegistrarIncidencia(string tipo, string descripcion, string fecha, string estado, string accion)
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

        Incidencia nuevaIncidencia = new Incidencia(contadorCodigo, tipo, descripcion, fecha, estado, accion);
        incidencias.Add(nuevaIncidencia);
        Console.WriteLine($"Incidencia registrada exitosamente con código {contadorCodigo}");
        contadorCodigo++;
    }
}