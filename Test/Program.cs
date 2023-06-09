using TelegramBotLibrary;

var bot = new TelegramBotClient("5936336198:AAFQ2RS5auQ0p6aSmM2qlRTaxmdRmsi_Jr8");
await bot.SendMessageAsync(561013085, "Hello");
var result = await bot.GetMeAsync();
Console.WriteLine(result.FirstName);