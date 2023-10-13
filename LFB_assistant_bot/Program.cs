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
        if (message != null)
            if (message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, OperatableText.GreetingsText,replyMarkup:CustomKeyboard.MenuPicker);
            }
        
        botClient.StartReceiving(MenuPick,Error);
    }

    private static async Task MenuPick(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var message = update.Message;

        switch (message.Text)
        {
            case OperatableText.AddOrder:
                await botClient.SendTextMessageAsync(message.Chat.Id, "З чого саме лабораторна вам потрібна?",
                    replyMarkup: CustomKeyboard.SubjectPicker);
                    botClient.StartReceiving(ChooseOrder,Error);
                break;
            case OperatableText.FindMore:
                await botClient.SendTextMessageAsync(message.Chat.Id, "FindMore",
                    replyMarkup: CustomKeyboard.MenuPicker);
                break;
            case OperatableText.ConnectBarman:
                await botClient.SendTextMessageAsync(message.Chat.Id, "В розробці",
                    replyMarkup: CustomKeyboard.MenuPicker);
                break;
            default:
                break;
        }
    }

    private static async Task ChooseOrder(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var message = update.Message;
        if (message?.Text != null)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, $"ChooseORder",
                replyMarkup: CustomKeyboard.MenuPicker);
            botClient.StartReceiving(AddOrder,Error);
            
        }
    }


    private static async Task AddOrder(ITelegramBotClient botClient, Update update, CancellationToken arg3)
    {
        var message = update.Message;

        OperatableText.Output = $"{message.Text} {message.Chat.Username ?? message.Chat.FirstName + " " + message.Chat.LastName}, AddOrder ";
        botClient.SendTextMessageAsync(message.Chat.Id, OperatableText.Output);
        botClient.StartReceiving(MenuPick,Error);
    }


    private static Task Error(ITelegramBotClient botClient, Exception update, CancellationToken arg3)
    {
        return Task.CompletedTask;
    }
}