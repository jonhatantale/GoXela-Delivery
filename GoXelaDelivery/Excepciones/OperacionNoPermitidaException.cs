using System;

class OperacionNoPermitidaException : Exception
{
    public OperacionNoPermitidaException(string mensaje) : base(mensaje)
    {
    }
}