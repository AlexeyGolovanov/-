using System;
using System.Net;
using System.Text;

namespace HttpClient
{
  public static class Client
  {
    public static string Ping(int port)
    {
      using var client = new WebClient();

      return client.DownloadString($"http://127.0.0.1:{port}/Ping");
    }
    public static Input GetInputData(int port)
    {
      using var client = new WebClient();

      var responseStr = client.DownloadString($"http://127.0.0.1:{port}/GetInputData");
      Console.WriteLine(responseStr);
      return Input.JsonDeserialize(responseStr);
    }

    public static void WriteAnswer(int port, Output answer)
    {
      var requestStr = answer.JsonSerialize();
      var request = Encoding.UTF8.GetBytes(requestStr);
      using var client = new WebClient();
      client.UploadData($"http://127.0.0.1:{port}/WriteAnswer", request);
    }
  }
}
