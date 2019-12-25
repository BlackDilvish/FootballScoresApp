using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootballScoresApp.ViewModel
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    static class RestClient
    {
        public static string EndPoint { get; set; }
        public static httpVerb HttpMethod { get; set; }
        private static string Key { get; set; }

        public static void InitRestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = httpVerb.GET;
            Key = "&APIkey=" + File.ReadAllText(@"..\..\Model\Key.txt");
        }

        public static string MakeRequest(string url)
        {
            EndPoint = url + Key;
            string responseValue = string.Empty;

            HttpWebRequest request = WebRequest.Create(EndPoint) as HttpWebRequest;
            request.Method = HttpMethod.ToString();

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new ApplicationException("Error: " + response.StatusDescription);

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return responseValue;
        }

    }
}
