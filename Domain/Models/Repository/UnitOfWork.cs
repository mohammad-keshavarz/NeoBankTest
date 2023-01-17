using Domain.Helper;

namespace Domain.Models.Repository;

public interface IUnitOfWork : IDisposable
{
    void Commit();
}

public class UnitOfWork : IUnitOfWork
{

    private NeoBankContext Context { get; }

    public UnitOfWork(NeoBankContext context)
    {
        Context = context;
    }

    public void Commit()
    {
        Context.SaveChanges();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
