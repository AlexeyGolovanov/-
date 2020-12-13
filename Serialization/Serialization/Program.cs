using System;

namespace Serialization
{
  class Program
  {
    static void Main()
    {
      var input = Console.ReadLine();
      string serType;
      var InObject = Input.Deserialize(input,out serType);
      var outObject = new Output(InObject);
      Console.WriteLine(outObject.Serialize(serType));
      Console.ReadLine();
    }
  }
}
