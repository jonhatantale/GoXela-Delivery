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