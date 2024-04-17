namespace Application.Common.Interfaces;

public interface IUnityOfWork
{
    Task CommitChangesAsync();
}