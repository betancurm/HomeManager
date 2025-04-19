using System.Runtime.Serialization;

namespace HomeManagment.Domain.Exceptions;
class DomainException : Exception
{
    public DomainException() { }
    public DomainException(string message) : base(message) { }
    public DomainException(string message, Exception innerException)
        : base(message, innerException) { }
}
