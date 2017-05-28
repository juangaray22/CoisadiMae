using System;
using System.Net.Http;

namespace CoisadiMae.Util.ConnectivityFunctions
{
    public sealed class BaseHttpClient
	{
		static volatile BaseHttpClient instance;
		static readonly object syncLock = new object();
		static HttpClient _baseHttpClient;

		BaseHttpClient()
		{
			var client = new HttpClient
			{
				BaseAddress = new Uri(Constants.WatsonBaseAPIURL),
				Timeout = TimeSpan.FromSeconds(50)
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
							instance = new BaseHttpClient();
					}
				}

				return _baseHttpClient;
			}
		}
	}
}