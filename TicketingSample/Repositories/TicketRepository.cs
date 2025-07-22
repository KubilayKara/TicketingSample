using System.Data;
using TicketingSample.Data;
using TicketingSample.Models;
using Dapper;


namespace TicketingSample.Repositories
{
    public class TicketRepository
    {
        private readonly IDbConnection _dbConnection;

        public TicketRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnection = dbConnectionFactory.CreateConnection();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var query = "SELECT * FROM Tickets";
            return _dbConnection.Query<Ticket>(query);
        }

        public Ticket GetTicketById(int id)
        {
            var query = "SELECT * FROM Tickets WHERE Id = @Id";
            return _dbConnection.QuerySingleOrDefault<Ticket>(query, new { Id = id });
        }
    }
}
