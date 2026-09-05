using System;
static class UtilidadesTarifa
{
    // Recargo por tipo de servicio: Normal 0%, Prioritario +25%, Urgente +50%
    public static double RecargoPorServicio(string tipoServicio)
    {
        if (string.IsNullOrWhiteSpace(tipoServicio))
            return 0;

        if (tipoServicio.Equals("Prioritario", StringComparison.OrdinalIgnoreCase))
            return 0.25;

        if (tipoServicio.Equals("Urgente", StringComparison.OrdinalIgnoreCase))
            return 0.50;

        return 0;
    }
}