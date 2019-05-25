using System;
using System.IO;
using Extracao_Selenium_CSV.Entities;
using Extracao_Selenium_CSV.Entities.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Extracao_Selenium_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver WebDriver = new ChromeDriver();
            Unemployees x = new Unemployees(WebDriver);
            Data data = new Data();


            x.WebDriver.Navigate().GoToUrl(x.HomeUrl);
            for (int i = 1; i < 20; i++)
            {
                string Country = x.GetCountry(i);
                double Percentual = x.GetPercentual(i);
                data.Dados.Add(new CountryData(Country, Percentual));
            }

            WebDriver.Close();
            Console.WriteLine("Insira o Path que deseja criar a pasta e colocar o arquivo: ");
            string targetPath = Console.ReadLine();
            Directory.CreateDirectory(targetPath);
            using (var sw = File.CreateText(targetPath + @"\resultados.csv")){
                sw.WriteLine("Índice de desemprego atualizado dos países G-20");
                sw.WriteLine("Percentual médio de desemprego: " + data.PercentualMedio().ToString("F2") + "%");
                sw.WriteLine(data.MaiorIndice());
                sw.WriteLine(data.MenorIndice());
                sw.WriteLine();
                sw.WriteLine("Lista de Países: ");
                foreach (var c in data.Dados)
                {
                    sw.WriteLine(c.ToString());
                }
            }
        }
    }
}
