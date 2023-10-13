using Telegram.Bot.Types.ReplyMarkups;

namespace LabForBeer_bot;

public static class CustomKeyboard
{
    public static  ReplyKeyboardMarkup MenuPicker = new(new[]
        {
            new KeyboardButton[] { OperatableText.AddOrder},
            new KeyboardButton[] { OperatableText.FindMore, OperatableText.ConnectBarman },
        }
    );
    public static  ReplyKeyboardMarkup SubjectPicker = new(new[]
        {
            new KeyboardButton[] { OperatableText.Mathcad, OperatableText.Programming },
            new KeyboardButton[] { OperatableText.OtherSubject, OperatableText.GoHome},
        }
    );
}