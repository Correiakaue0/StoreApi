using Domain.Enum;
using Domain.Utils;
using System.Text.Json;

namespace Service.Services;

public class BaseService
{
    #region MessageError
    
    public string MessageCannotBeEmpty(string propertyName)
    {
        var messageTranslated = TranslateAsync($"{propertyName} cannot be empty.");
        return messageTranslated.Result;
    }

    public string MessageAlreadyRegistered(string propertyName)
    {
        var messageTranslated = TranslateAsync($"{propertyName} already registered.");
        return messageTranslated.Result;
    }

    public string MessageNotFound<TEntry>()
    {
        var entryName = typeof(TEntry).Name;
        var messageTranslated = TranslateAsync($"{entryName} not found.");
        return messageTranslated.Result;
    }
    #endregion

    protected static async Task<string> TranslateAsync(string text)
    {
        using var client = new HttpClient();

        var langPair = DataSession.Language == EnumLanguage.English ? "pt|en" : "en|pt";
        var url = $"https://api.mymemory.translated.net/get?q={Uri.EscapeDataString(text)}&langpair={langPair}";

        var response = await client.GetStringAsync(url);

        using var json = JsonDocument.Parse(response);

        if (json.RootElement.TryGetProperty("responseStatus", out var statusElement) && statusElement.ValueKind == JsonValueKind.Number && statusElement.GetInt32() == 429)
            throw new Exception("Limite diário de caracteres de traduções excedido");

        return json.RootElement.GetProperty("responseData").GetProperty("translatedText").GetString();
    }
}