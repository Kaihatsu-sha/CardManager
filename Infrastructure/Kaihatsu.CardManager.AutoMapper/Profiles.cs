using AutoMapper;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.Entities.Dto;
using Kaihatsu.CardManager.Request;

namespace Kaihatsu.CardManager.AutoMapper;

internal class Profiles: Profile
{
    public Profiles()
    {
        CreateCardMaps();
        CreateClientMaps();
    }

    private void CreateCardMaps()
    {
        CreateMap<Card, CardDto>();
        CreateMap<CreateCardRequest, Card>();
        CreateMap<UpdateCardRequest, Card>();
        CreateMap<DeleteCardRequest, Card>();
    }

    private void CreateClientMaps()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientRequest, Client>();
        CreateMap<UpdateClientRequest, Client>();
        CreateMap<DeleteClientRequest, Client>();
    }
}
