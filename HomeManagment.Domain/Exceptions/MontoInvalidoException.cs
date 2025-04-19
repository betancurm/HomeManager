namespace HomeManagment.Domain.Exceptions;
class MontoInvalidoException : DomainException
{
    public MontoInvalidoException(decimal amount)
        : base($"El monto {amount} es inválido. Debe ser mayor a cero") { }
}
