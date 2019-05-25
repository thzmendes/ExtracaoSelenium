namespace Extracao_Selenium_CSV.Entities
{
    internal class CountryData
    {
        public CountryData(string name, double percentual)
        {
            Name = name;
            Percentual = percentual;
        }

        public string Name { get; set; }
        public double Percentual { get; set; }

        public override string ToString()
        {
            return "País: " + Name + ", " + Percentual + "%" +
                   "";
        }
    }
}