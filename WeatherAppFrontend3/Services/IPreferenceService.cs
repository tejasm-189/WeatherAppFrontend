public interface IPreferenceService
{
    Task<bool> GetDarkModePreference();
    Task SetDarkModePreference(bool isDarkMode);
} 