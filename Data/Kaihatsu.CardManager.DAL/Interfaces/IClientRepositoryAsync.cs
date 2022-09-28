using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.DAL.Entities;

namespace Kaihatsu.CardManager.DAL.Interfaces;

public interface IClientRepositoryAsync :IRepositoryAsync<Client, Guid>
{
}
