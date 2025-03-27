using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<(int, int), Application.Sales.GetSales.GetSalesCommand>()
            .ConstructUsing(x => new Application.Sales.GetSales.GetSalesCommand(x.Item1, x.Item2));
        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
