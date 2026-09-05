using System;
using System.Collections.Generic;

class GestorVehiculos
{
    private List<Vehiculo> vehiculos = new List<Vehiculo>();

    
    private int contador = 1;

    public void RegistrarVehiculo(int tipo, string placa, string marca, string modelo, int capacidad, double costoBase, bool tieneRefri = false)
    {
        if (capacidad <= 0)
        {
            Console.WriteLine("Capacidad inválida, intentelo de nuevo....");
            return;
        }

        if (costoBase < 0)
        {
            Console.WriteLine("Capacidad inválida, intentelo de nuevo...");
            return;
        }

        // Crear el vehículo según el tipo (1=Bici, 2=Moto, 3=Auto)
        Vehiculo Vehiculo1;
        try
        {
            if (tipo == 1)
                Vehiculo1 = new Bicicleta(contador, marca, modelo, capacidad, costoBase);
            else if (tipo == 2)
                Vehiculo1 = new Motocicleta(contador, placa, marca, modelo, capacidad, costoBase);
            else if (tipo == 3)
                Vehiculo1 = new Automovil(contador, placa, marca, modelo, capacidad, costoBase, tieneRefri);
            else
            {
                Console.WriteLine("El vehiculo seleccionado no existe, vuelva a intentarlo...");
                return;
            }

            vehiculos.Add(Vehiculo1);
            Console.WriteLine($"Vehículo registrado exitosamente con código {contador}");
            contador++;
        }
        catch (Exception error)
        {
            Console.WriteLine($"Error al registrar vehículo: {error.Message}");
        }
    }

    public Vehiculo ConsultarVehiculo(int codigo)
    {
        foreach (var cod in vehiculos)
        {
            if (cod.Codigo == codigo)
            {
                cod.MostrarInformacion();
                return cod;
            }
        }
        Console.WriteLine("Vehiculo no encontrado");
        return null;
    }

    public void ListarVehiculos()
    {
        if (vehiculos.Count == 0)
        {
            Console.WriteLine("No hay vehículos registrados");
            return;
        }

        foreach (var veh in vehiculos)
        {
            veh.MostrarInformacion();
            Console.WriteLine("---");
        }
    }

    public void CambiarEstadoVehiculo(int codigo, EstadoVehiculo nuevoEstado)
    {
        foreach (var v in vehiculos)
        {
            if (v.Codigo == codigo)
            {
                v.CambiarEstado(nuevoEstado);
                Console.WriteLine($"Estado del vehículo {codigo} cambiado a {nuevoEstado}");
                return;
            }
        }
        Console.WriteLine("Vehiculo no encontrado...");
    }

    public List<Vehiculo> ObtenerVehiculosDisponibles()
    {
        List<Vehiculo> disponibles = new List<Vehiculo>();
        foreach (var v in vehiculos)
        {
            if (v.EstaDisponible())
                disponibles.Add(v);
        }
        return disponibles;
    }

    public bool PuedeTransportarPaquete(int codigoVehiculo, Paquete paquete)
    {
        foreach (var v in vehiculos)
        {
            if (v.Codigo == codigoVehiculo)
                return v.PuedeTransportar(paquete);
        }
        Console.WriteLine("Vehículo no encontrado");
        return false;
    }

    public Vehiculo ObtenerVehiculoPorCodigo(int codigo)
    {
        foreach (var v in vehiculos)
        {
            if (v.Codigo == codigo)
                return v;
        }
        return null;
    }
}