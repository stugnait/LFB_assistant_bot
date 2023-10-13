using System;
using LabForBeer_bot;
using Telegram.Bot;
using Telegram.Bot.Types;

class Program
{
    private const string Token = "6609430462:AAFE6KgQFIlD_YRvYvFGF-IBdFDHaOJ6gT8";
    private static TelegramBotClient client;
    
    static void Main(string[] args)
    {
        client = new TelegramBotClient(Token);
        client.StartReceiving(FirstUpdate,Error);

        Console.ReadLine();
    }

    

    private static async Task FirstUpdate(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var message = update.Message;
        if (message != null) await botClient.SendTextMessageAsync(message.Chat.Id, OperatableText.GreetingsText,replyMarkup:CustomKeyboard.MenuPicker);
        botClient.StartReceiving(MenuPick,Error);
    }

    private static async Task MenuPick(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var message = update.Message;

        if (message != null) await botClient.SendTextMessageAsync(message.Chat.Id, message.Text,replyMarkup:CustomKeyboard.MenuPicker);
        switch (message.Text)
        {
            case :
        }
    }


    private static Task Error(ITelegramBotClient botClient, Exception update, CancellationToken arg3)
    {
        return Task.CompletedTask;
    }
}