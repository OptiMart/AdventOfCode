using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC.AdventOfCode.Connector
{
    internal class Connector
    {
        private static readonly string _baseUrl = "adventofcode.com";
        private static readonly string _scheme = "https";

        private string _basePath;

        private readonly string _session;

        public Connector(string session)
        {
            _session= session;
        }

        private Cookie GetSessionCookie(string session)
        {
            return new Cookie("session", session);
        }

        
        public string GetPuzzleInput(int year, int day)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(GetInputUrl(year, day));

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(BaseUrl, GetSessionCookie(_session));

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string responseText = reader.ReadToEnd();

            return responseText;
        }

        public bool SavePuzzleInput(int year, int day)
        {
            var filePath = GetInputPath(year, day);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, GetPuzzleInput(year, day));

            return true;
        }

        public bool SubmitPuzzleAnswer(int year, int day, int part, string answer)
        {
            CookieContainer cc = new CookieContainer();
            cc.Add(BaseUrl, GetSessionCookie(_session));

            var handler = new HttpClientHandler() { CookieContainer = cc };
            HttpClient client = new HttpClient(handler);

            var values = new Dictionary<string, string>()
            {
                {"level", part.ToString() },
                {"answer", answer }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync(GetAnswerUrl(year, day), content);
            response.Wait();

            var responseString = response.Result.Content;

            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(GetAnswerUrl(year, day));

            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(BaseUrl, GetSessionCookie(_session));
            //request.Method = "POST";

            //WebResponse response = request.GetResponse();

            //StreamReader reader = new StreamReader(response.GetResponseStream());

            //string responseText = reader.ReadToEnd();

            return true;
        }

        public static Uri BaseUrl
        {
            get {
                var uribuilder = new UriBuilder()
                {
                    Scheme = _scheme,
                    Host = _baseUrl
                };
                return uribuilder.Uri;
            }
        }

        public string BasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_basePath))
                    _basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

                return _basePath;
            }
            set
            {
                if (_basePath != value)
                    _basePath = value;
            }
        }

        public static Uri GetInputUrl(int year, int day)
        {
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = _scheme,
                Host = _baseUrl,
                Path = $@"{year:0000}/day/{day}/input"
            };
            return uriBuilder.Uri;
        }

        public string GetInputPath(int year, int day)
        {
            return Path.Combine(BasePath, $@"Input\{year}\Input_Day{day:00}.txt");
        }

        public static Uri GetAnswerUrl(int year, int day)
        {
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme= _scheme,
                Host = _baseUrl,
                Path = $@"{year:0000}/day/{day}/answer"
            };
            return uriBuilder.Uri;
        }
    }
}
