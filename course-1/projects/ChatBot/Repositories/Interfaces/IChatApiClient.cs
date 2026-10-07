using ChatBot.Repositories.Models;

public interface IChatApiClient
{
    Task<string> SendMessageAsync(string userMessage, IEnumerable<OpenApiResponse.Message> history);

}