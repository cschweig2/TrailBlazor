using System.Collections.Generic;

namespace TrailBlazor.Models
{
    public class CurrentUser
    {
        public static bool IsAuthenticated { get; set; }
        public static string UserName { get; set; }
        public Dictionary<string, string> Claims { get; set; }
        public static string UserId { get; set; }
        public const string Uid = "EpVNlJlQ3Ra9m8Lw0Ie348BflZg1";
        public const string Role = "Admin";
    }
}
