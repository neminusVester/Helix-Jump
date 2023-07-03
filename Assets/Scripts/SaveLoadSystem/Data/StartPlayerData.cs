using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StartPlayerData", order = 1)]
public class StartPlayerData : ScriptableObject
{
    public int StartDamage;
    public float StartSpeed;
    public int StartBagSize;
    public int MoneyCoin;
}
