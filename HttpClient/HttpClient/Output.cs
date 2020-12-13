using System;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace HttpClient
{
  [Serializable]
  public class Output
  {
    [XmlElement("SumResult")]
    public decimal SumResult { get; set; }
    [XmlElement("MulResult")]
    public int MulResult { get; set; }
    [XmlArray("SortedInputs")]
    [XmlArrayItem("decimal")]
    public decimal[] SortedInputs { get; set; }

    public Output()
    { }

    public Output(Input inObject)
    {
      this.SumResult = inObject.Sums.Sum() * inObject.K;
      var multiplication = 1;
      foreach (var mul in inObject.Muls)
      {
        multiplication *= mul;
      }

      this.MulResult = multiplication;

      this.SortedInputs = new decimal[inObject.Muls.Length + inObject.Sums.Length];
      var muls = inObject.Muls.Select(x => (decimal)x).ToArray();
      muls.CopyTo(SortedInputs, 0);
      inObject.Sums.CopyTo(SortedInputs, inObject.Muls.Length);
      Array.Sort(this.SortedInputs);
    }

    public string JsonSerialize()
    {
      return JsonSerializer.Serialize<Output>(this);
    }
  }
}