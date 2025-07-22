using Dapper;
using System.Data;

public static class SeedData
{
    public static void Initialize(IDbConnection dbConnection)
    {
        //TODO
        var createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Tickets (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Description TEXT NOT NULL,
                CreatedAt TEXT NOT NULL
            );
        ";
        dbConnection.Execute(createTableQuery);

        var insertDataQuery = @"
            INSERT INTO Tickets (Title, Description, CreatedAt) 
            VALUES 
            ('Sample Ticket 1', 'Description for ticket 1', '2025-07-17'),
            ('Sample Ticket 2', 'Description for ticket 2', '2025-07-17');
        ";
        dbConnection.Execute(insertDataQuery);
    }
}