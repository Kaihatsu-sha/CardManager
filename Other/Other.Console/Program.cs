using Other.JWT;
// See https://aka.ms/new-console-template for more information

TokenGenerator generatorJWT = new TokenGenerator();
string jwtToken = generatorJWT.Authenticate("Paper");

Console.WriteLine(jwtToken);
Console.ReadKey();