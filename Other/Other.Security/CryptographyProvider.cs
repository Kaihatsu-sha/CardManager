using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace Other.Security;

public class CryptographyProvider
{
    static byte[] additionalEntropy = { 1, 1, 3, 1, 1, 6 };

    public void ProtectData(string data)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(String));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
                {
                    xmlSerializer.Serialize(xmlTextWriter, data);
                    byte[] protectedData = Protect(memoryStream.ToArray());
                }                   
            }
                
        }
        catch (Exception e)
        {
            throw new SerializeCryptographyProviderException();
        }
    }

    private byte[] Protect(byte[] data)
    {
        try
        {
            return ProtectedData.Protect(data, additionalEntropy, DataProtectionScope.LocalMachine);
        }
        catch (Exception e)
        {
            throw new ProtectCryptographyProviderException();
        }
    }


    public string GetProtectedData()
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(String));
            byte[] protectedData = File.ReadAllBytes("data.protected");
            byte[] data = Unprotect(protectedData);
            return (String)xmlSerializer.Deserialize(new MemoryStream(data));
        }
        catch (Exception e)
        {
            Console.WriteLine("Deserialize data error.");
            throw new DeserializeCryptographyProviderException();
        }
    }

    private byte[] Unprotect(byte[] data)
    {
        try
        {
            return ProtectedData.Unprotect(data, additionalEntropy, DataProtectionScope.LocalMachine);
        }
        catch (Exception e)
        {
            throw new UnprotectCryptographyProviderException();
        }
    }
}