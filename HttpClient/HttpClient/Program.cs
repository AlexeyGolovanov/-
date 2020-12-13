using System;
using System.Net;

namespace HttpClient
{
  class Program
  {
    static void Main()
    {
      int.TryParse(Console.ReadLine(),out var port);

      using var client = new WebClient();

      var input = Client.GetInputData(port);
      Client.WriteAnswer(port, new Output(input));
    }
  }
}
