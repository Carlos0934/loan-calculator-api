namespace Api.Infrastructure.Endpoints;
using Api.App.CalculateLoan;
using MediatR;


public static class LoanEndpointsExtension
{
    public static void MapLoanEndpoints(this WebApplication app)
    {
        app.MapGet("/loan/calculate", async ([AsParameters] CalculateLoanRequest request, IMediator mediator) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        });
    }
}