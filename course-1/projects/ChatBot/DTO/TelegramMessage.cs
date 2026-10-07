using ChatBot.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Telegram.Bot.Types;

namespace ChatBot.Dtos
{
    public class TelegramMessage
    {
        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        [JsonPropertyName("from")]
        public TelegramUser? From { get; set; }

        [JsonPropertyName("chat")]
        public TelegramChat? Chat { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("date")]
        public int Date { get; set; }
    }
}
    