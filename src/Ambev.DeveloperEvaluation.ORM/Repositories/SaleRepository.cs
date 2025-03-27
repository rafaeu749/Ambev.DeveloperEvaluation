using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task<Sale?> GetByNumberAsync(int number, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.FirstOrDefaultAsync(o=> o.Number == number, cancellationToken);
    }

    public async Task<List<Sale>> GetWithPaginationAsync(int page, int total, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.Skip(page - 1).Take(total).ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var oldSale = await GetByNumberAsync(sale.Number, cancellationToken);
        if (oldSale == null)
            return false;

        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int number, CancellationToken cancellationToken = default)
    {
        var sale = await GetByNumberAsync(number, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> CancelAsync(int number, CancellationToken cancellationToken = default)
    {
        var sale = await GetByNumberAsync(number, cancellationToken);
        if (sale == null)
            return false;

        sale.Cancel();

        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
