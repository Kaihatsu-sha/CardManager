namespace Kaihatsu.CardManager.Core.Interfaces;

public interface IResponse
{
    int ErrorCode { get; set; }
    string? ErrorMessage { get; set; }
}
