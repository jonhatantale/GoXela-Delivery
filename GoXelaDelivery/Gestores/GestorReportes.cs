using System;
using System.Collections.Generic;

class GestorReportes
{
    private GestorClientes gestorClientes;
    private GestorRepartidores gestorRepartidores;
    private GestorVehiculos gestorVehiculos;
    private GestorPaquetes gestorPaquetes;
    private GestorIncidencias gestorIncidencias;

    public GestorReportes(GestorClientes clientesCons, GestorRepartidores repartidoresCons, GestorVehiculos vehiculosCons,GestorPaquetes paquetesCons,GestorIncidencias incidenciasCons)
    {
        gestorClientes = clientesCons;
        gestorRepartidores = repartidoresCons;
        gestorVehiculos = vehiculosCons;
        gestorPaquetes = paquetesCons;
        gestorIncidencias = incidenciasCons;
    }
    public void ReporteClientesRegistrados()
    {
        List<Cliente> clientes = gestorClientes.Clientes;
        Console.WriteLine($"--- Clientes registrados ({clientes.Count}) ---");
        foreach (Cliente c in clientes)
        {
            c.MostrarInformacion();
        }
    }
    public void ReporteRepartidoresRegistrados()
    {
        List<Repartidor> repartidores = gestorRepartidores.Repartidores;
        Console.WriteLine($"--- Repartidores registrados ({repartidores.Count}) ---");
        foreach (Repartidor r in repartidores)
        {
            r.MostrarInformacion();
        }
    }
    public void ReporteVehiculosRegistrados()
    {
        List<Vehiculo> vehiculos = gestorVehiculos.Vehiculos;
        Console.WriteLine($"--- Vehículos registrados ({vehiculos.Count}) ---");
        foreach (Vehiculo v in vehiculos)
        {
            v.MostrarInformacion();
        }
    }
    public void ReportePaquetesRegistrados()
    {
        List<Paquete> paquetes = gestorPaquetes.Paquetes;
        Console.WriteLine($"--- Paquetes registrados ({paquetes.Count}) ---");
        foreach (Paquete p in paquetes)
        {
            p.MostrarInformacion();
        }
    }
    public void ReporteRepartidoresDisponibles()
    {
        List<Repartidor> repartidores = gestorRepartidores.Repartidores;
        int disponibles = 0;
        Console.WriteLine("--- Repartidores disponibles ---");
        foreach (Repartidor r in repartidores)
        {
            if (r.EstaDisponible())
            {
                r.MostrarInformacion();
                disponibles++;
            }
        }
        Console.WriteLine($"Total disponibles: {disponibles}");
    }
    public void ReporteVehiculosDisponibles()
    {
        List<Vehiculo> disponibles = gestorVehiculos.ObtenerVehiculosDisponibles();
        Console.WriteLine($"--- Vehículos disponibles ({disponibles.Count}) ---");
        foreach (Vehiculo v in disponibles)
        {
            v.MostrarInformacion();
        }
    }
    public void ReporteIncidenciasRegistradas()
    {
        List<Incidencia> incidencias = gestorIncidencias.Incidencias;
        Console.WriteLine($"--- Incidencias registradas ({incidencias.Count}) ---");
        foreach (Incidencia i in incidencias)
        {
            i.MostrarInformacion();
        }
    }
    public void ReportePaquetesConCondicionEspecial()
    {
        List<Paquete> paquetes = gestorPaquetes.Paquetes;
        Console.WriteLine("--- Paquetes con condición especial ---");

            foreach(Paquete p in paquetes)
        {
            if (p.RequiereCondicionEspecial())
            {
                p.MostrarInformacion();
            }
        }
    }
    public void ReporteResumenGeneral()
    {
        Console.WriteLine("--- Resumen general del sistema ---");
        Console.WriteLine($"Clientes: {gestorClientes.Clientes.Count}");
        Console.WriteLine($"Repartidores: {gestorRepartidores.Repartidores.Count}");
        Console.WriteLine($"Vehículos: {gestorVehiculos.Vehiculos.Count}");
        Console.WriteLine($"Paquetes: {gestorPaquetes.Paquetes.Count}");
        Console.WriteLine($"Incidencias: {gestorIncidencias.Incidencias.Count}");
    }
    private int ContarRepartidoresDisponibles(List<Repartidor> repartidores, int indice)
    {
        if (indice >= repartidores.Count)
        {
            return 0;
        }
        int cuentaActual = repartidores[indice].EstaDisponible() ? 1 : 0;
        return cuentaActual + ContarRepartidoresDisponibles(repartidores, indice + 1);
    }
    public void ReporteConteoDisponibles()
    {
        List<Repartidor> repartidores = gestorRepartidores.Repartidores;
        int total = ContarRepartidoresDisponibles(repartidores, 0);
        Console.WriteLine($"--- Conteo recursivo de repartidores disponibles: {total} ---");
    }
}