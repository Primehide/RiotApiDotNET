using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotApiDotNET
{
    public class RiotClient
    {
        private string Apikey;
        private Enums.Server Server;
       
        public RiotClient(string apikey, Enums.Server server)
        {
            Apikey = apikey;
            Server = server;
    }

        private async Task<SUMMONER_V3.SummonerDTO> SendRequest()
        {
            string baseUriSummoner = "https://" + Server.ToString() + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/";


            using (HttpClient http = new HttpClient())
            {
                string uri = baseUriSummoner;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SUMMONER_V3.SummonerDTO>(jsonString);
            }
        }

        //SUMMONER-V3 Methods
        /*
        public SUMMONER_V3.SummonerDTO GetSummonerById(long accountid)
        {

        }
        */
    }
}
