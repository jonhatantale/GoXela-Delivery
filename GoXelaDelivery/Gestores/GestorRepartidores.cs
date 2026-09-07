using System;
using System.Collections.Generic;

class GestorRepartidores
{
    private List<Repartidor> repartidores = new List<Repartidor>();
    public List<Repartidor> Repartidores
    {
        get { return repartidores; }
    }

    private int contador = 1;
    
    public void RegistrarRepartidor(string nombre, int telefono, int licencia, string tipoLicencia)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Error. El nombre no puede estar vacio.");
            return;
        }
        if (telefono <= 0)
        {
            Console.WriteLine("Error: El teléfono debe ser valido.");
            return;
        }
        if(licencia <=0)
        {
            Console.WriteLine("Error: El numero de licencia debe ser valido.");
            return;
        }
        if (string.IsNullOrWhiteSpace(tipoLicencia))
        {
            Console.WriteLine("Error. El tipo de licencia no puede estar vacio.");
            return;
        }
        foreach(Repartidor r in repartidores)
        {
            if(r.NumeroLicencia == licencia)
            {
                Console.WriteLine("Error: Ya existe un repartidor registrado con esa licencia");
                return;
            }
        }
        Repartidor nuevoRepartidor = new Repartidor(contador, nombre, telefono, licencia, tipoLicencia);
        repartidores.Add(nuevoRepartidor);
        Console.WriteLine($"Repartidor registrado exitosamente con código {contador}");
        contador++;
    }
    public Repartidor ObtenerRepartidorPorCodigo(int codigo)
    {
        foreach (var r in repartidores)
        {
            if (r.Codigo == codigo)
                return r;
        }
        return null;
    }
    public Repartidor ConsultarRepartidor(int codigo)
    {
        foreach (var r in repartidores)
        {
            if (r.Codigo == codigo)
            {
                r.MostrarInformacion();
                return r;
            }
        }
        Console.WriteLine("Repartidor no encontrado");
        return null;
    }

    public void ListarRepartidores()
    {
        if (repartidores.Count == 0)
        {
            Console.WriteLine("No hay repartidores registrados");
            return;
        }

        foreach (var r in repartidores)
        {
            r.MostrarInformacion();
            Console.WriteLine("---");
        }
    }

    public void CambiarEstadoRepartidor(int codigo, EstadoRepartidor nuevoEstado)
    {
        foreach (var r in repartidores)
        {
            if (r.Codigo == codigo)
            {
                r.Estado = nuevoEstado;
                Console.WriteLine($"Estado del repartidor {codigo} actualizado a {nuevoEstado}");
                return;
            }
        }
        Console.WriteLine("Repartidor no encontrado");
    }
}