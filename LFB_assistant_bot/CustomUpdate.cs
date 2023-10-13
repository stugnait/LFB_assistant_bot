using Telegram.Bot;
using Telegram.Bot.Types;

namespace LabForBeer_bot;



public static class CustomUpdate
{
    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        return Task.CompletedTask;
    }
    
}