using System;

[Serializable]
public class GameDataSaves
{
    public StoredValue<int> Level;
    public StoredValue<int> Coins;
    public StoredValue<float> SphereSize;
    public StoredValue<int> Damage;
    public StoredValue<int> DamageLv;
    public StoredValue<int> BagSize;
    public StoredValue<int> CurBagResCount;
    public StoredValue<int> CurBagResLv;
    public StoredValue<float> MoveSpeed;
    public StoredValue<int> MoveSpeedLv;
    public StoredValue<int> TutorialState;
    public StoredValue<bool> VenderUnlock;
    public StoredValue<int> VenderMoneyNeed;

    public Res[] res;
    [Serializable]
    public class Res
    {
        public StoredValue<int> Resource = new StoredValue<int>(0);
    }

    public GameDataSaves()
    {
        VenderMoneyNeed = new StoredValue<int>(100);
        VenderUnlock = new StoredValue<bool>(false);
        TutorialState = new StoredValue<int>(0);
        CurBagResCount = new StoredValue<int>(0);
        BagSize = new StoredValue<int>(50);
        Damage = new StoredValue<int>(1);
        MoveSpeed = new StoredValue<float>(4);
        SphereSize = new StoredValue<float>(5);
        Level = new StoredValue<int>(1);
        Coins = new StoredValue<int>(20);
        DamageLv = new StoredValue<int>(0);
        CurBagResLv = new StoredValue<int>(0);
        MoveSpeedLv = new StoredValue<int>(0);
        res = new Res[8];
    }
}