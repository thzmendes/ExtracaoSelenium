using System.Text;

namespace Extracao_Selenium_CSV.Entities
{
    internal class CountryData
    {
        public string Name { get; set; }
        public double Percentual { get; set; }

        public CountryData(string name, double percentual)
        {
            Name = name;
            Percentual = percentual;
        }

        public override string ToString()
        {
          
            return "País: "+Name+", "+Percentual+"%";
        }
    }
}