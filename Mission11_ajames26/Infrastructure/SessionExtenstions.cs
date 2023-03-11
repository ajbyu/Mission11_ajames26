using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Mission11_ajames26.Infrastructure
{
    public static class SessionExtenstions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            //Serialize object and save to session storage
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T> (this ISession session, string key)
        {
            //Deserialize json to object of type T
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
