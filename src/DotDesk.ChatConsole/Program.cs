using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Replace with the correct URL for your SignalR hub
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5051/chat") // Change this if using HTTPS or another port
            .Build();

        // Register a handler for incoming messages
        connection.On<string, string, string>("ReceiveMessage", (user, message, timestamp) =>
        {
            Console.WriteLine($"[{timestamp}] {user}: {message}");
        });

        try
        {
            // Start the connection
            await connection.StartAsync();
            Console.WriteLine("Connected to the hub!");

            // Send a test message
            await connection.InvokeAsync("SendMessage", "general", "test_user", "Hello from C# client!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the hub: {ex.Message}");
        }

        // Keep the connection open
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
