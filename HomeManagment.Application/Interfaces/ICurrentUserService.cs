namespace HomeManagment.Application.Interfaces;

public interface ICurrentUserService
{
    Guid ApplicationUserId { get; }
}
