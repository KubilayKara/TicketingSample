using Microsoft.AspNetCore.Builder;

namespace TicketingSample.Routes
{
    public static class TicketEndpoints
    {
        public static void MapTicketEndpoints(this WebApplication app)
        {
            app.MapGet("/tickets", () => Results.Ok(new[] { "Ticket1", "Ticket2" }));
            
            // app.MapPost("/tickets", ...);
            // app.MapPut("/tickets/{id}", ...);
            // app.MapDelete("/tickets/{id}", ...);

        }
    }
}
