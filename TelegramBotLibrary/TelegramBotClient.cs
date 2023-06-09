using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TelegramBotLibrary.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TelegramBotLibrary
{
    public class TelegramBotClient
    {
        private readonly string _requestUrl;
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Create instance of bot to use
        /// </summary>
        /// <param name="token">This token you can get by https://t.me/BotFather</param>
        public TelegramBotClient(string token)
        {
            _requestUrl = $"https://api.telegram.org/bot{token}/";
            _httpClient = new HttpClient();
        }

        private async Task SendRequestToApiAsync<T>(string command, T value)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUrl+command, value);
            response.EnsureSuccessStatusCode();
        }

        private async Task<R> SendRequestToApiAsync<T,R>(string command,T value)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUrl + command, value);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<R>();
            return result;
        }
        private async Task<T> SendRequestToApiAsync<T>(string command)
        {
            var response = await _httpClient.GetAsync(_requestUrl+command);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>();
            return result;
        }
        /// <summary>
        /// Get general information about bot
        /// </summary>
        public async Task<GetMeResult> GetMeAsync()
        {
            var result = await SendRequestToApiAsync<Response<GetMeResult>>("getMe");
            return result.Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId">Id of chat to send message</param>
        /// <param name="text">Text to send</param>
        /// <returns></returns>
        public async Task SendMessageAsync(int chatId,string text)
        {

            await SendRequestToApiAsync("sendMessage", new { chat_id = chatId, text });
        }
    }
}
