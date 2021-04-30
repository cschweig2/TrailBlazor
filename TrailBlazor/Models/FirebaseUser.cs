using System.Collections.Generic;

namespace TrailBlazor.Models
{
    public class FirebaseUser
    {
        public string Uid { get; set; }
        public object DisplayName { get; set; }
        public object PhotoURL { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public object PhoneNumber { get; set; }
        public bool IsAnonymous { get; set; }
        public object TenantId { get; set; }
        public List<ProviderData> ProviderData { get; set; }
        public string ApiKey { get; set; }
        public string AppName { get; set; }
        public string AuthDomain { get; set; }
        public StsTokenManager StsTokenManager { get; set; }
        public object RedirectEventId { get; set; }
        public string LastLoginAt { get; set; }
        public string CreatedAt { get; set; }
        public MultiFactor MultiFactor { get; set; }
    }

    public class ProviderData
    {
        public string Uid { get; set; }
        public object DisplayName { get; set; }
        public object PhotoURL { get; set; }
        public string Email { get; set; }
        public object PhoneNumber { get; set; }
        public string ProviderId { get; set; }
    }

    public class StsTokenManager
    {
        public string ApiKey { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public long ExpirationTime { get; set; }
    }

    public class MultiFactor
    {
        public List<object> EnrolledFactors { get; set; }
    }
}
