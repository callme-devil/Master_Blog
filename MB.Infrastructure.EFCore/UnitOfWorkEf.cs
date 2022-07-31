using _01_Framework.Infrastructure.UnitOfWork;
using MB.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore;

public class UnitOfWorkEf : IUnitOfWork
{
    private readonly MasterBlogContext _context;

    public UnitOfWorkEf(MasterBlogContext context)
    {
        _context = context;
    }

    public void BeginTran()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTran()
    {
        _context.SaveChanges();

        _context.Database.CommitTransaction();
    }

    public void RollBack()
    {
        _context.Database.RollbackTransaction();
    }
}