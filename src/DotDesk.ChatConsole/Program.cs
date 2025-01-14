using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        string userName = Guid.NewGuid().ToString();

        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5051/chat")
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            if (user != userName)
                Console.WriteLine($"Received message from user {user}: {message}");
        });

        Console.WriteLine($"User {userName} from console connected to the hub!");

        try
        {
            await connection.StartAsync();
            Console.WriteLine("Connection established with the server!");

            // Join the room
            await connection.InvokeAsync("JoinRoom", "general");
            Console.WriteLine("Joined the room: general");

            // Start the message input loop
            while (true)
            {
                Console.Write("");
                string message = Console.ReadLine();

                // Send the message to the hub
                await connection.InvokeAsync("SendMessage", "general", userName, message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to the hub: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
