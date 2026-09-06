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
}