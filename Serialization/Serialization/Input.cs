using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serialization
{
  [Serializable]
  [XmlRoot(ElementName = "Input")]
  public class Input
  {
    [XmlElement("K")]
    public int K { get; set; }

    [XmlArray("Sums")]
    [XmlArrayItem("decimal")]
    public decimal[] Sums { get; set; }

    [XmlArray("Muls")]
    [XmlArrayItem("int")]
    public int[] Muls { get; set; }

    public static Input Deserialize(string input, out string serType)
    {
      if (input[0] == '<')
      {
        serType = "XML";
        return XMLDeserialize(input);
      }
      serType = "JSON";
      return JSONDeserialize(input);
    }

    private static Input XMLDeserialize(string input)
    {
      Input InObject = new Input();
      XElement xElement = XElement.Parse(input);

      StringReader reader = new StringReader(xElement.ToString());
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(Input));
      InObject = (Input)xmlSerializer.Deserialize(reader);

      return InObject;
    }

    private static Input JSONDeserialize(string input)
    {
      Input InObject = JsonSerializer.Deserialize<Input>(input);
      return InObject;
    }
  }
}
