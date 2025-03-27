using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public record GetSalesCommand : IRequest<List<GetSaleResult>>
{
    public int Page { get; }
    public int Total { get; }

    public GetSalesCommand(int page, int total)
    {
        Page = page;
        Total = total;
    }
}
