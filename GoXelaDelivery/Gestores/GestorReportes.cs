using System;
using System.Collections.Generic;

class GestorReportes
{
    private GestorEntregas gestorEntregas;
    private GestorRepartidores gestorRepartidores;
    private GestorVehiculos gestorVehiculos;
    private GestorPaquetes gestorPaquetes;

    public GestorReportes(GestorEntregas entregasCons, GestorRepartidores repartidoresCons, GestorVehiculos vehiculosCons, GestorPaquetes paquetesCons)
    {
        gestorEntregas = entregasCons;
        gestorRepartidores = repartidoresCons;
        gestorVehiculos = vehiculosCons;
        gestorPaquetes = paquetesCons;
    }

    public void ReporteEntregasActivas()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;
        Console.WriteLine("--- Entregas activas ---");
        int contador = 0;
        foreach (Entrega e in entregas)
        {
            if (!e.Estado.Equals("Entregada", StringComparison.OrdinalIgnoreCase) &&
                !e.Estado.Equals("Cancelada", StringComparison.OrdinalIgnoreCase))
            {
                e.MostrarInformacion();
                contador++;
            }
        }
        Console.WriteLine($"Total activas: {contador}");
    }

    public void ReporteEntregasFinalizadas()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;
        Console.WriteLine("--- Entregas finalizadas ---");
        int contador = 0;
        foreach (Entrega e in entregas)
        {
            if (e.Estado.Equals("Entregada", StringComparison.OrdinalIgnoreCase))
            {
                e.MostrarInformacion();
                contador++;
            }
        }
        Console.WriteLine($"Total finalizadas: {contador}");
    }

    public void ReporteEntregasCanceladas()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;
        Console.WriteLine("--- Entregas canceladas ---");
        int contador = 0;
        foreach (Entrega e in entregas)
        {
            if (e.Estado.Equals("Cancelada", StringComparison.OrdinalIgnoreCase))
            {
                e.MostrarInformacion();
                contador++;
            }
        }
        Console.WriteLine($"Total canceladas: {contador}");
    }

    public void ReporteEntregasConIncidencias()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;
        Console.WriteLine("--- Entregas con incidencias ---");
        int contador = 0;
        foreach (Entrega e in entregas)
        {
            if (e.Incidencias.Count > 0)
            {
                e.MostrarInformacion();
                contador++;
            }
        }
        Console.WriteLine($"Total con incidencias: {contador}");
    }

    public void ReporteRepartidoresDisponibles()
    {
        List<Repartidor> repartidores = gestorRepartidores.Repartidores;
        Console.WriteLine("--- Repartidores disponibles ---");
        int contador = 0;
        foreach (Repartidor r in repartidores)
        {
            if (r.EstaDisponible())
            {
                r.MostrarInformacion();
                contador++;
            }
        }
        Console.WriteLine($"Total disponibles: {contador}");
    }

    public void ReporteRepartidorConMasEntregas()
    {
        List<Repartidor> repartidores = gestorRepartidores.Repartidores;

        if (repartidores.Count == 0)
        {
            Console.WriteLine("No hay repartidores registrados");
            return;
        }

        Repartidor mejor = repartidores[0];
        foreach (Repartidor r in repartidores)
        {
            if (r.CantidadEntregas > mejor.CantidadEntregas)
            {
                mejor = r;
            }
        }

        Console.WriteLine("--- Repartidor con más entregas ---");
        mejor.MostrarInformacion();
    }

    public void ReporteVehiculoMasUtilizado()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;

        List<int> codigosVistos = new List<int>();
        List<int> vecesUsado = new List<int>();

        foreach (Entrega e in entregas)
        {
            int codigoVehiculo = e.Vehiculo.Codigo;

            int posicion = codigosVistos.IndexOf(codigoVehiculo);

            if (posicion == -1)
            {
                codigosVistos.Add(codigoVehiculo);
                vecesUsado.Add(1);
            }
            else
            {
                vecesUsado[posicion] = vecesUsado[posicion] + 1;
            }
        }

        if (codigosVistos.Count == 0)
        {
            Console.WriteLine("No hay entregas registradas todavía");
            return;
        }

        int indiceMax = 0;
        for (int i = 1; i < vecesUsado.Count; i++)
        {
            if (vecesUsado[i] > vecesUsado[indiceMax])
            {
                indiceMax = i;
            }
        }

        int codigoMasUsado = codigosVistos[indiceMax];
        int maxUsos = vecesUsado[indiceMax];

        Vehiculo vehiculo = gestorVehiculos.ObtenerVehiculoPorCodigo(codigoMasUsado);
        Console.WriteLine("--- Vehículo más utilizado ---");
        if (vehiculo != null)
        {
            vehiculo.MostrarInformacion();
        }
        Console.WriteLine($"Usado en {maxUsos} entregas");
    }

    public void ReporteCantidadPaquetesPorTipo()
    {
        List<Paquete> paquetes = gestorPaquetes.Paquetes;
        int documentos = 0;
        int estandar = 0;
        int fragiles = 0;
        int refrigerados = 0;

        foreach (Paquete p in paquetes)
        {
            if (p is Documento)
                documentos++;
            else if (p is PaqueteEstandar)
                estandar++;
            else if (p is PaqueteFragil)
                fragiles++;
            else if (p is ProductoRefrigerado)
                refrigerados++;
        }

        Console.WriteLine("--- Cantidad de paquetes por tipo ---");
        Console.WriteLine($"Documentos: {documentos}");
        Console.WriteLine($"Estándar: {estandar}");
        Console.WriteLine($"Frágiles: {fragiles}");
        Console.WriteLine($"Refrigerados: {refrigerados}");
    }

    private double SumarIngresosRecursivo(List<Entrega> entregas, int indice)
    {
        if (indice >= entregas.Count)
        {
            return 0;
        }

        double montoActual = 0;
        if (entregas[indice].Estado.Equals("Entregada", StringComparison.OrdinalIgnoreCase))
        {
            montoActual = entregas[indice].Total;
        }

        return montoActual + SumarIngresosRecursivo(entregas, indice + 1);
    }

    public void ReporteTotalIngresos()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;
        double total = SumarIngresosRecursivo(entregas, 0);
        Console.WriteLine($"--- Total de ingresos (entregas finalizadas): Q{total:F2} ---");
    }

    public void ReporteEntregaConMayorCosto()
    {
        List<Entrega> entregas = gestorEntregas.Entregas;

        if (entregas.Count == 0)
        {
            Console.WriteLine("No hay entregas registradas todavía");
            return;
        }

        Entrega mayorCosto = entregas[0];
        foreach (Entrega e in entregas)
        {
            if (e.Total > mayorCosto.Total)
            {
                mayorCosto = e;
            }
        }

        Console.WriteLine("--- Entrega con mayor costo ---");
        mayorCosto.MostrarInformacion();
    }
}