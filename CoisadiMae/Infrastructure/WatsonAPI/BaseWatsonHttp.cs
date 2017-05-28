using System;
using System.Net.Http;
using CoisadiMae.Util;

namespace CoisadiMae.Infrastructure.WatsonAPI
{
    public class BaseWatsonHttp
    {
        static volatile BaseWatsonHttp instance;
        static readonly object syncLock = new object();
        static HttpClient _baseHttpClient;

        BaseWatsonHttp()

        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Constants.WatsonBaseAPIURL),
                Timeout = TimeSpan.FromSeconds(10)
            };

            _baseHttpClient = client;
        }


        public static HttpClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new BaseWatsonHttp();
                    }
                }

                return _baseHttpClient;
            }
        }
    }
}