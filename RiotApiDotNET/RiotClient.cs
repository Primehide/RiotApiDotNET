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

        private async Task<SUMMONER_V3.SummonerDTO> SendRequest(int WhichMethod,string Summonername = "", long AccountId = 0, long SummonerId = 0)
        {
            string baseUri = "https://" + Server.ToString() + ".api.riotgames.com/lol/summoner/v3/summoners/";

            if(WhichMethod == 1)
            {
                baseUri = baseUri + "/by-name/" + Summonername + "?api_key=" + Apikey;
            }
            else if(WhichMethod == 2)
            {
                baseUri = baseUri + "/by-account/" + AccountId + "?api_key=" + Apikey;
            }
            else
            {
                baseUri = baseUri + SummonerId + "?api_key=" + Apikey;
            }


            using (HttpClient http = new HttpClient())
            {
                string uri = baseUri;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SUMMONER_V3.SummonerDTO>(jsonString);
            }
        }

        //SUMMONER-V3 Methods
        public SUMMONER_V3.SummonerDTO GetSummonerByName(string Summonername)
        {
            return SendRequest(1,Summonername: Summonername).Result;
        }

        public SUMMONER_V3.SummonerDTO GetSummonerByAccountId(long AccountId)
        {
            return SendRequest(2,AccountId: AccountId).Result;
        }

        public SUMMONER_V3.SummonerDTO GetSummonerBySummonerId(long SummonerId)
        {
            return SendRequest(3,SummonerId: SummonerId).Result;
        }
    }
}
