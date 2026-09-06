using System;

class ValorInvalidoException : Exception
{
    public ValorInvalidoException(string mensaje) : base(mensaje)
    {
    }
}
