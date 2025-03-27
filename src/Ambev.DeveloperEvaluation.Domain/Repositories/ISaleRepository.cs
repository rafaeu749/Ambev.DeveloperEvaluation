using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    Task<Sale?> GetByNumberAsync(int number, CancellationToken cancellationToken = default);
    
    Task<List<Sale>> GetWithPaginationAsync(int page, int total, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    Task<bool> CancelAsync(int number, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int number, CancellationToken cancellationToken = default);
}
