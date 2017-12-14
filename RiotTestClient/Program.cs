using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotApiDotNET;

namespace RiotTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RiotClient client = new RiotClient("RGAPI-7dbd7ac3-2c1d-4d04-a9f2-8be56256711a", RiotApiDotNET.Enums.Server.EUW1);
            RiotApiDotNET.SUMMONER_V3.SummonerDTO summoner = client.GetSummonerBySummonerId(28041965);
            Console.WriteLine(summoner.name);
            Console.ReadLine();
        }
    }
}
