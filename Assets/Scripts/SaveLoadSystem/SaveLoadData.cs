using System;
using System.Collections.Generic;

[Serializable]
public class SaveLoadData
{
    public GameDataSaves Game;
    public SettingsData Settings;
    public StoredValue<int> PlayCount;
    public StoredValue<int> TutorialFinger;
    public StoredValue<int> MaxScore;
    public StoredValue<int> CurrentLevel;

    public SaveLoadData()
    {

        Game = new GameDataSaves();
        Settings = new SettingsData();
        PlayCount = new StoredValue<int>(0);
        TutorialFinger = new StoredValue<int>(0);
        MaxScore = new StoredValue<int>(0);
        CurrentLevel = new StoredValue<int>(1);
    }
}