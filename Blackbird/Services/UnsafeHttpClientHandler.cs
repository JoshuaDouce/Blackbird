namespace Blackbird.Services
{
    public class UnsafeHttpClientHandler : HttpClientHandler
    {
        public UnsafeHttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}
