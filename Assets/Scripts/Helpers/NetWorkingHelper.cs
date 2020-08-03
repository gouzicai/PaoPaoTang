using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class NetWorkingHelper : MonoBehaviour
{
    public const string basic_url = "http://localhost:1111";
    public static string Post(string url,byte[] data)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(basic_url + url);
        Debug.Log(basic_url + url);
        req.Method = "POST";
        using (Stream resStream = req.GetRequestStream())
        {
            resStream.Write(data, 0, data.Length);
        }
        string result = string.Empty;
        HttpWebResponse res =  (HttpWebResponse)req.GetResponse();
        using(Stream resStream = res.GetResponseStream())
        {
           using(StreamReader reader = new StreamReader(resStream))
            {
                result = reader.ReadToEnd();
            }
        }
        return result;
    }
}
