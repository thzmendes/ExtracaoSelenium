using System.Collections.Generic;

namespace Extracao_Selenium_CSV.Entities
{
    internal class Data
    {
        public List<CountryData> Dados = new List<CountryData>(); 

        public double PercentualMedio()
        {
            double somaPercentual = 0;
            int contador = 0;
            foreach (var d in Dados)
            {
                contador++;
                somaPercentual += d.Percentual;
            }

            return somaPercentual / contador;
        }

        public string MenorIndice()
        {
            
            double percentualMenor = 100;
            CountryData menorIndice = null;
            foreach (var d in Dados)
            {
                
                if (d.Percentual < percentualMenor)
                {
                    percentualMenor = d.Percentual;
                    menorIndice = d;
                }
            }

            return "Menor Índice: "+menorIndice.Name + " " + menorIndice.Percentual.ToString("F2")+"%";
        }

        public string MaiorIndice()
        {
            
            double percentualMaior = 0;
            CountryData maiorIndice = null;
            foreach (var d in Dados)
            {
                
                if (d.Percentual > percentualMaior)
                {
                    percentualMaior = d.Percentual;
                    maiorIndice = d;
                }
            }

            return "Maior Índice: "+maiorIndice.Name + " " + maiorIndice.Percentual.ToString("F2")+"%";
        }
    }
}