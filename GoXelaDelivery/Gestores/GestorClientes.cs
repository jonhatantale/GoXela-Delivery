using System;
using System.Collections.Generic;

class GestorClientes
{
    private List<Cliente> clientes = new List<Cliente>();
    private int contador = 1;

    public void RegistrarCliente(string nombre, int telefono, string correo, string direccion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Error: El nombre no puede estar vacío");
            return;
        }

        if (telefono <= 0)
        {
            Console.WriteLine("Error: El teléfono debe ser válido");
            return;
        }

        if (string.IsNullOrWhiteSpace(correo))
        {
            Console.WriteLine("Error: El correo no puede estar vacío");
            return;
        }

        if (string.IsNullOrWhiteSpace(direccion))
        {
            Console.WriteLine("Error: La dirección no puede estar vacía");
            return;
        }

        Cliente nuevoCliente = new Cliente(contador, nombre, telefono, correo, direccion);
        clientes.Add(nuevoCliente);
        Console.WriteLine($"Cliente registrado exitosamente con código {contador}");
        contador++;
    }

    public Cliente ConsultarCliente(int codigo)
    {
        foreach (var cli in clientes)
        {
            if (cli.Codigo == codigo)
            {
                cli.MostrarInformacion();
                return cli;
            }
        }
        Console.WriteLine("Cliente no encontrado");
        return null;
    }

    public void ListarClientes()
    {
        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados");
            return;
        }

        foreach (var c in clientes)
        {
            c.MostrarInformacion();
            Console.WriteLine("---");
        }
    }

    public void ActualizarCliente(int codigo, string nuevoCorreo, string nuevaDireccion)
    {
        foreach (var c in clientes)
        {
            if (c.Codigo == codigo)
            {
                if (!string.IsNullOrWhiteSpace(nuevoCorreo))
                    c.Correo = nuevoCorreo;
                if (!string.IsNullOrWhiteSpace(nuevaDireccion))
                    c.Direccion = nuevaDireccion;
                Console.WriteLine($"Cliente {codigo} actualizado exitosamente");
                return;
            }
        }
        Console.WriteLine("Cliente no encontrado");
    }

    public Cliente ObtenerClientePorCodigo(int codigo)
    {
        foreach (var c in clientes)
        {
            if (c.Codigo == codigo)
                return c;
        }
        return null;
    }

    public int ContarClientes()
    {
        return clientes.Count;
    }
}