using Kaihatsu.CardManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.CardManager.Response;

public class AuthorizationResponse : IResponse
{
    public int ErrorCode {get;set;}
    public string? ErrorMessage { get; set; }
}
