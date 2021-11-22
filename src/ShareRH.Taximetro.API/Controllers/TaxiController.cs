using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareRH.Taximetro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiCalculationController : ControllerBase
    {
        public List<string> passag = new List<string>();

        [HttpPost] public double Calctrip(DateTime hours,int dist,string nomePassString,string param2)
        {
            if (hours != null)
            {
                if (dist > 0 && dist != 0)
                {
                    double valuePerMt = 0.1;
                    //Mudança de município
                    if (dist > 100)
                    {
                        valuePerMt = 0.15; }
                    //Valor começa com zero
                    double result = 0;
                    //Bandeira 2
                    if (hours.Hour > 22 || hours.Hour < 6) {
                                valuePerMt *= 2; }
                    //é domingo
                    else if (hours.DayOfWeek == 0)
                    {
                    valuePerMt *= 2;
                    }

                    passag.Add(nomePassString);
                    //Distancia * o valor 
                    result = valuePerMt * dist; return result;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }

        [HttpGet]
        public string NomeUltimo() { var ult = ""; if(passag.Count > 3) { ult = passag.LastOrDefault(); } else { ult = "vc não completou a quantidade de passageiros suficientes"; } return ult; }
    }
}
