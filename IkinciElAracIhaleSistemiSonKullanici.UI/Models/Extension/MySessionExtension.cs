﻿using Newtonsoft.Json;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Models.Extension
{
    public static class MySessionExtension
    {
        public static void MySessionSet(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));

        }
        public static T MySessionGet<T>(this ISession session, string key)
        {
            var hede = session.GetString(key);

            return hede == null ? default(T) : JsonConvert.DeserializeObject<T>(hede);
        }
    }
}
