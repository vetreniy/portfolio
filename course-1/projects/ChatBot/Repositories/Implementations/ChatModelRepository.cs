using System.Text.Json;
using ChatBot.Dtos;
using ChatBot.Repositories.Interfaces;
using ChatBot.Repositories.Models;

namespace ChatBot.Repositories.Implementations
{
    public class ChatModelRepository : IChatModelRepository
    {
        private readonly string _storagePath;
        private readonly ILogger<ChatModelRepository> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public ChatModelRepository(ILogger<ChatModelRepository> logger)
        {
            _logger = logger;
            _storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "ChatHistory");

            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
        }

        private string GetChatFilepath(long chatId)
        {
            return Path.Combine(_storagePath, $"chat_{chatId}.json");
        }

        public async Task AddMessageAsync(long chatId, OpenApiResponse.Message message)
        {
            _logger.LogInformation("Сохранение сообщения от чата {ChatId}: {Role}", chatId, message.Role);

            var history = await GetHistoryAsync(chatId);
            history.Add(message);

            var filePath = GetChatFilepath(chatId);
            var json = JsonSerializer.Serialize(history, _jsonOptions);
            await File.WriteAllTextAsync(filePath, json);
        }

        public Task<List<OpenApiResponse.Message>> GetHistoryAsync(long chatId)
        {
            _logger.LogInformation("Загрузка истории для чата {ChatId}", chatId);

            var filePath = GetChatFilepath(chatId);

            if (!File.Exists(filePath))
            {
                return Task.FromResult(new List<OpenApiResponse.Message>());
            }

            try
            {
                var json = File.ReadAllText(filePath);
                var history = JsonSerializer.Deserialize<List<OpenApiResponse.Message>>(json, _jsonOptions);
                return Task.FromResult(history ?? new List<OpenApiResponse.Message>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке истории для чата {ChatId}", chatId);
                return Task.FromResult(new List<OpenApiResponse.Message>());
            }
        }

        public async Task<ChatStats> GetStatsAsync(long chatId)
        {
            _logger.LogInformation("Подсчёт статистики для чата {ChatId}", chatId);

            var history = await GetHistoryAsync(chatId);
            var stats = new ChatStats();

            foreach (var msg in history)
            {
                if (msg.Role == "user")
                {
                    stats.UserMessages++;
                    stats.EstimatedUserTokens += (int)Math.Ceiling(msg.Content.Length / 3.0);
                }
                else if (msg.Role == "assistant")
                {
                    stats.AssistantMessages++;
                    stats.EstimatedAssistantTokens += (int)Math.Ceiling(msg.Content.Length / 3.0);
                }
            }

            return stats;
        }

        public async Task ClearHistoryAsync(long chatId)
        {
            _logger.LogInformation("Очистка истории для чата {ChatId}", chatId);

            var filePath = GetChatFilepath(chatId);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            await Task.CompletedTask;
        }

        public async Task<bool> RemoveLastMessageAsync(long chatId)
        {
            _logger.LogInformation("Удаление последнего сообщения для чата {ChatId}", chatId);

            var history = await GetHistoryAsync(chatId);

            if (history.Count > 0)
            {
                history.RemoveAt(history.Count - 1);

                var filePath = GetChatFilepath(chatId);
                var json = JsonSerializer.Serialize(history, _jsonOptions);
                await File.WriteAllTextAsync(filePath, json);

                return true;
            }

            return false;
        }
    }
}