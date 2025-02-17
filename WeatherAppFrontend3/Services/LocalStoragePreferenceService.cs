using Blazored.LocalStorage;
using MudBlazor;

namespace WeatherApp.Services
{ 
    using Blazored.LocalStorage;
    public class LocalStoragePreferenceService : IPreferenceService
{
    private readonly ILocalStorageService _localStorage;
    private const string DARK_MODE_KEY = "darkMode";

    public LocalStoragePreferenceService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<bool> GetDarkModePreference()
    {
        try
        {
            var darkMode = await _localStorage.GetItemAsync<bool?>(DARK_MODE_KEY);
            return darkMode ?? false; // Return false as default if no preference is set
        }
        catch
        {
            return false; // Return false as default if any error occurs
        }
    }

    public async Task SetDarkModePreference(bool isDarkMode)
    {
        await _localStorage.SetItemAsync(DARK_MODE_KEY, isDarkMode);
    }
} 

}