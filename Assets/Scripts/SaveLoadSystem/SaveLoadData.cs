using System;
using System.Collections.Generic;

[Serializable]
public class SaveLoadData
{
    public GameDataSaves Game;
    public SettingsData Settings;
    public StoredValue<int> PlayCount;
    public StoredValue<int> TutorialFinger;

    public SaveLoadData()
    {

        Game = new GameDataSaves();
        Settings = new SettingsData();
        PlayCount = new StoredValue<int>(0);
        TutorialFinger = new StoredValue<int>(0);
    }
}