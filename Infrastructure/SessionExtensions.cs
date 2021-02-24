using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
namespace Orphanage.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetString(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetString<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
            ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}