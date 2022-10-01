
namespace Kaihatsu.CardManager.Authorization.Entities;

[Flags] //TODO : Flags!
public enum AuthorizationStatus
{
    Success = 0,
    UserNotFound = 1,
    InvalidPassword = 2,
    ExriredToken =3,
    InvalidToken =4
}
