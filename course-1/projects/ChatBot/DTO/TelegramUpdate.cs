using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ChatBot.Dtos
{
    public class TelegramUpdate
    {
        [JsonPropertyName("update_id")]
        public int UpdateId { get; set; }

        [JsonPropertyName("message")]
        public TelegramMessage? Message { get; set; }

    }
}