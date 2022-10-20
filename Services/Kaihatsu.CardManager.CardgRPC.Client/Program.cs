using Grpc.Net.Client;
using Kaihatsu.CardManager.CardgRPC.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kaihatsu.CardManager.CardgRPC.Protos.CardService;
using static Kaihatsu.CardManager.CardgRPC.Protos.ClientService;

namespace Kaihatsu.CardManager.CardgRPC.Client;

internal class Program
{
    static void Main(string[] args)
    {
        AppContext.SetSwitch("System.Net.Http.SocketHttpHandler.Http2UnencryptedSupport", true);

        //CardServiceClient
        //ClientServiceClient

        using var channel = GrpcChannel.ForAddress("http://localhost:5001");

        ClientServiceClient clientService = new ClientServiceClient(channel);

        var createClientResponse = clientService.Create(new CreateClientRequest
        {
            FirstName = "FirstName",
            SurName = "SurName",
            Patronymic = "Patronymic"
        });

        Console.WriteLine($"Client {createClientResponse.Id} created successfully.");

        CardServiceClient cardService = new CardServiceClient(channel);

        var getByClientIdResponse = cardService.GetByIdCard(new GetByIdCardRequest
        {
            Id = "1"
        });

        Console.WriteLine(getByClientIdResponse.ToString());

        Console.ReadKey();

    }
}
