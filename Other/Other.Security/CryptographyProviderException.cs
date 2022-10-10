using System.Runtime.CompilerServices;

namespace Other.Security;

public abstract class CryptographyProviderBaseException : Exception
{
    //public CryptographyProviderBaseException(string message) : base(message)
    //{
    //}
}

public class SerializeCryptographyProviderException : CryptographyProviderBaseException { }
public class DeserializeCryptographyProviderException : CryptographyProviderBaseException { }

public class ProtectCryptographyProviderException : CryptographyProviderBaseException { }
public class UnprotectCryptographyProviderException : CryptographyProviderBaseException { }
