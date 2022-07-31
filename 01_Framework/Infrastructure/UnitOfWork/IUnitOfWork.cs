namespace _01_Framework.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTran();

        void CommitTran();

        void RollBack();
    }
}
