using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name;
    public int BuyPrice;
    public int SellPrice;
    public string Description;
    public SpriteSlot Slot;
    public EquipmentType Type;
    [JsonIgnore] public List<Sprite> Sprite;
    [JsonIgnore] public Sprite Icon;
}

public enum SpriteSlot
{
    Pelvis,
    Torso,
    LegL,
    LegR,
    ElbowL,
    ElbowR,
    Head,
    Face,
    Hood,
    ShoulderL,
    ShoulderR,
    HandL,
    HandR,
    BootsL,
    BootsR,
    MainWeapon,
    Offhand
}

public enum EquipmentType
{
    Armor,
    Helm,
    Boots,
    Gloves,
}
