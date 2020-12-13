using System;
using System.Text.Json;
using System.Xml.Serialization;

namespace HttpClient
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

    public static Input JsonDeserialize(string input)
    {
      Input InObject = JsonSerializer.Deserialize<Input>(input);
      return InObject;
    }
  }
}
