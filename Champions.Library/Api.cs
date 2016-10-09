using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Champions.Library
{
    public class Api
    {
        #region Web Request Functions

        public static void AddArgument(Dictionary<string, string> arguments, string key, string value)
        {
            arguments.Remove(key); //will return false if not found...
            arguments.Add(key, value);
        }

        public static string GetArguments(Dictionary<string, string> arguments)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in arguments)
            {
                EncodeAndAddItem(parameters, kvp.Key, kvp.Value);
            }

            return parameters.ToString();
        }

        public static void EncodeAndAddItem(StringBuilder baseRequest, string key, string dataItem)
        {
            if (baseRequest == null)
            {
                baseRequest = new StringBuilder();
            }
            if (baseRequest.Length != 0)
            {
                baseRequest.Append("&");
            }
            baseRequest.Append(key);
            baseRequest.Append("=");
            baseRequest.Append(HttpUtility.UrlEncode(dataItem));
        }

        public static string SendPostRequest(string URL, Dictionary<string, string> arguments, string contentType = "application/x-www-form-urlencoded")
        {
            HttpWebRequest request;
            string postData = GetArguments(arguments);

            Uri uri = new Uri(URL);
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.Accept = contentType;
            request.ContentType = contentType;
            request.ContentLength = postData.Length;

            using (Stream writeStream = request.GetRequestStream())
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(postData);
                writeStream.Write(bytes, 0, bytes.Length);
            }

            request.AllowAutoRedirect = true;

            UTF8Encoding enc = new UTF8Encoding();

            string result = string.Empty;

            HttpWebResponse Response;
            try
            {
                using (Response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = Response.GetResponseStream())
                    {
                        using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            return readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine("Error: " + exc.Message);
                throw exc;
            }
        }

        #endregion
    }
}