using System.Text.Json.Serialization;

namespace Pokemon.Models
{
    public class PokemonAbilityModel
    {

        public int PokemonUrl { get; set; }

        public string? PokemonAbilityName { get; set; }
    }

    public class Response<T> : Response
        where T : class
    {
        public T Data { get; set; }

        public static Response<T> Success(T data, string message)
        {
            return new Response<T>
            {
                IsSuccessful = true,
                Message = message,
                Data = data,
            };
        }

        public static new Response<T> Fail(string message)
        {
            return new Response<T>
            {
                IsSuccessful = false,
                Message = message,
            };
        }
    }
    public class Response
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public Response()
        {
            IsSuccessful = default;
            Message = default;
        }

        public static Response Success(string message)
        {
            return new Response
            {
                IsSuccessful = true,
                Message = message,
            };
        }

        public static Response Fail(string message)
        {
            return new Response
            {
                IsSuccessful = false,
                Message = message,
            };
        }
    }

    public record class PokemonModel(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] string previous,
    [property: JsonPropertyName("results")] object results);
}
