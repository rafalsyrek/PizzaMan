using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace PizzaManDelivery
{
    class DistanceFinder
    {
        public double getDistanceBetweenLocations(Adress start, Adress end)
        {
            if (start == end)
            {
                throw new Exception("Error in: getDistanceBetweenLocations. start == end");
            }
            HttpWebRequest request = createRequestForCalculatingDistance(start, end);
            string responsereader = getResponse(request);
            return getDistanceFromXml(responsereader);
        }

        private static double getDistanceFromXml(string responsereader)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                if(distance[0].ChildNodes[1].InnerText.Contains("km"))
                {
                    return 1000 * Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" km", ""));
                }
                else return Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" m", ""));
            }

            throw new Exception("Error in: getDistanceFromXml");
        }
        private static string getResponse(HttpWebRequest request)
        {
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            return responsereader;
        }

        private static HttpWebRequest createRequestForCalculatingDistance(Adress start, Adress end)
        {
            string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" +
                          start.toGoogleString() + "&destinations=" + end.toGoogleString() +
                          "&mode=driving&sensor=false&language=en-EN";
            return (HttpWebRequest)WebRequest.Create(url);
        }

    }
}
