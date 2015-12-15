using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpManager
{
    public sealed class HttpClientManager
    {
        private static HttpClientManager _instance = null;
        private static readonly object _lock = new object();

        public static HttpClientManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HttpClientManager();
                    }
                    return _instance;
                }
            }
        }

        public async Task<string> Request(string url)
        {
            var uri = new Uri(url);
            var httpClient = new HttpClient();

            try
            {
                var result = await httpClient.GetStringAsync(uri);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // Details in ex.Message and ex.HResult.    
                return string.Empty;
            }
        }
    }
}
