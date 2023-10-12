using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item Template", order = 0)]
public class ItemSO : ScriptableObject
{
    public string Name;
    public int BuyPrice;
    public int SellPrice;
    public string Description;
    [HideInInspector] public SpriteSlot Slot;
    public EquipmentType Type;
    [JsonIgnore] public List<Sprite> Sprite;
    [JsonIgnore] public Sprite Icon;
}
