using System;
using System.Collections.Generic;
class GestorPaquetes
{
    private List<Paquete> paquetes = new List<Paquete>();
    private int contador = 1;

    public void RegistrarDocumento(string descripcion, double peso, double valorDeclarado, string origen, string destino)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("Error. La descripción no puede estar vacia.");
            return;
        }
        if (peso <= 0)
        {
            Console.WriteLine("Error: El peso debe ser mayor a 0");
            return;
        }
        Documento nuevoPaquete = new Documento(contador, descripcion, peso, valorDeclarado, origen, destino);
        paquetes.Add(nuevoPaquete);
        Console.WriteLine($"Documento registrado exitosamente con código {contador}");
        contador++;
    }
    public void RegistrarPaqueteEstandar(string descripcion,double peso, double valorDeclarado, string origen, string destino)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("Error. La descripción no puede estar vacia.");
            return;
        }
        if (peso <= 0)
        {
            Console.WriteLine("Error: El peso debe ser mayor a 0");
            return;
        }
        PaqueteEstandar nuevoPaquete = new PaqueteEstandar(contador, descripcion, peso, valorDeclarado, origen, destino);
        paquetes.Add(nuevoPaquete);
        Console.WriteLine($"Paquete estándar registrado  con código {contador}");
        contador++;
    }
    public void RegistrarPaqueteFragil(string descripcion, double peso, double valorDeclarado, string origen, string destino)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("Error. La descripción no puede estar vacia.");
            return;
        }
        if (peso <= 0)
        {
            Console.WriteLine("Error: El peso debe ser mayor a 0");
            return;
        }
        PaqueteFragil nuevoPaquete = new PaqueteFragil (contador,descripcion,peso,valorDeclarado, origen, destino);
        paquetes.Add(nuevoPaquete);
        Console.WriteLine($"Paquete frágil registrado con código {contador}");
        contador++;
    }
    public void RegistrarProductoRefrigerado(string descripcion, double peso, double valorDeclarado, string origen, string destino, double? temperaturaMaxima, double temperaturaMinima)
    {
        if(string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("Error. La descripción no puede estar vacia.");
            return;
        }
        if (peso <= 0)
        {
            Console.WriteLine("Error: El peso debe ser mayor a 0");
            return;
        }
        if (temperaturaMaxima == null)
        {
            Console.WriteLine("Error: Debe especificar la temperatura máxima requerida ");
            return;
        }
        ProductoRefrigerado nuevoPaquete = new ProductoRefrigerado(contador, descripcion, peso, valorDeclarado, origen, destino, temperaturaMaxima.Value, temperaturaMinima);
        paquetes.Add(nuevoPaquete);
        Console.WriteLine($"Producto refrigerado registrado con código {contador}");
        contador++;
    }
}