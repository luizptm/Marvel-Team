using Champions.Library;
using Marvel.Api;
using Marvel.Api.Filters;
using Marvel.Api.Model.DomainObjects;
using Marvel.Api.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MebApplication.Library
{
    public class ApiMarvel
    {
        string privatekey = "04c622dee4c8feaf3d73b215eff06d6d1fa2e003";
        string publickey = "6d208f29a49730c185d8ebb6ed1363c7";
       
        public List<Character> GetCharacters(int? offset = 0)
        {
            List<Character> heroes = new List<Character>();
            Marvel.Api.Filters.CharacterRequestFilter f = new Marvel.Api.Filters.CharacterRequestFilter();
            f.OrderBy(OrderResult.NameAscending);
            f.Offset = offset;
           
            var client = new MarvelRestClient(publickey, privatekey);
            CharacterResult r = client.FindCharacters(f);
            int i = 1;
            foreach (Character c in r.Data.Results)
            {
                if (c.Name == "" || c.Description == "" || c.Thumbnail == null && i > 10)
                {
                    continue;
                }
                heroes.Add(c);
                i++;
            }
            return heroes;
        }

        public List<Character> GetCharacters2(int? offset = 0)
        {
            List<Character> heroes = new List<Character>();

            Dictionary<string, string> arguments = new Dictionary<string, string>();
            /*
            Api.AddArgument(arguments, "apikey", publickey);
            Api.AddArgument(arguments, "offset", "10");
            Api.AddArgument(arguments, "limit", "50");
            */
            String resultJson = Api.SendPostRequest("http://gateway.marvel.com:80/v1/public/characters?limit=10&offset=" + offset + "&apikey=" + publickey, arguments, "application/json");
            CharacterResult resultCall = new CharacterResult();
            if (resultJson != "")
            {
                resultCall = (CharacterResult)JsonConvert.DeserializeObject(resultJson, typeof(CharacterResult));
            }

            int i = 1;
            foreach (Character c in resultCall.Data.Results)
            {
                if (c.Name == "" || c.Description == "" || c.Thumbnail == null && i > 10)
                {
                    continue;
                }
                heroes.Add(c);
                i++;
            }
            return heroes;
        }

        public int CharacterPower(string characterId)
        {
            var client = new MarvelRestClient(publickey, privatekey);
            string comics = client.FindCharacterComics(characterId).Data.Count;
            int power = Int32.Parse(comics);
            return power;
        }

        public Character FindCharacter(string characterId)
        {
            var client = new MarvelRestClient(publickey, privatekey);
            Character c = client.FindCharacter(characterId).Data.Results.First();
            return c;
        }
    }
}
