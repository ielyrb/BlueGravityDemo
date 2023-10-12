using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<ItemSO> itemDatabase;
    [SerializeField] List<Sprite> itemIcons;

    public Sprite GetRandomSprite()
    {
        return itemIcons[Random.Range(0, itemIcons.Count-1)];
    }

    public ItemSO GetItemByName(string itemName)
    {
        return itemDatabase.Find(x => x.name == itemName);
    }
}
