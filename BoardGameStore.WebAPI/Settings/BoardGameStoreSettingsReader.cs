namespace BoardGameStore.WebAPI.Settings;

public static class BoardGameStoreSettingsReader
{
    public static BoardGameStoreSettings Read(IConfiguration configuration)
    {
        return new BoardGameStoreSettings();
    }
}