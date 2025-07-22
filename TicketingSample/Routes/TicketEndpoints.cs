using Microsoft.AspNetCore.Builder;
using TicketingSample.Services;

namespace TicketingSample.Routes
{
    public static class TicketEndpoints
    {
        public static void MapTicketEndpoints(this WebApplication app)
        {
            app.MapGet("/tickets", (TicketService service) =>
            {
                return Results.Ok(service.GetAllTickets());
            });

            // app.MapPost("/tickets", ...);
            // app.MapPut("/tickets/{id}", ...);
            // app.MapDelete("/tickets/{id}", ...);

        }
    }
}
