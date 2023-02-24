using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Pokemon.Interface;
using Pokemon.Constants;
using Pokemon.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Collections.Generic;

namespace HttpClientCardService
{
    class PokemonService : IPokemon
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private async Task<object> HttpCall(string UriName = "")
        {
            if (UriName == "")
            {
                using (HttpClient client = new HttpClient())
                {
                    var url = Constants.EndPoint;
                    url += (UriName == "") ? Constants.ActionGetAll : Constants.ActionGetDetails + UriName;

                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                        if (UriName == "")
                        {
                            return JsonSerializer.Deserialize<PokemonModel>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        }
                        return JsonSerializer.Deserialize<object>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    }
                    else
                    {
                        // return a custome error message
                    }
                }
            }

            return await _httpClient.GetStringAsync(Constants.EndPoint + UriName);
        }

        public async Task<Response<PokemonModel>> GetPokemon()
        {
            var response = this.HttpCall();
            var contentBody = response.Result;

            return new Response<PokemonModel>()
            {
                IsSuccessful = true,
                Message = Constants.successful,
                Data = (PokemonModel)contentBody
            };
        }

        public Task<object> GetPokemonDetail(string pokemoneName)
        {

            var response = this.HttpCall(pokemoneName);

            return response;
        }

    }
}