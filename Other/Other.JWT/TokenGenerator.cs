using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Other.JWT;

public class TokenGenerator
{
    private const string SecretCode = "УБелкиПушистыйХвост";

    public string Authenticate(string user)
    {
        if (string.IsNullOrWhiteSpace(user))
        {
            return string.Empty;
        }

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(string nameIdentifier)
    {
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(SecretCode);


        SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
        securityTokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(15);
        securityTokenDescriptor.Issuer = "Issuer";
        //securityTokenDescriptor.Claims = "Issuer";

        securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        securityTokenDescriptor.Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim("SecretType","SecretValue")
            });

        SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        return jwtSecurityTokenHandler.WriteToken(securityToken);
    }
}
