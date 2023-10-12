using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    ItemSO item;
    string itemName;
    int itemPrice;
    [SerializeField] Image image;

    public void Randomize()
    {
        image.sprite = Manager.ItemManager.GetRandomSprite();
        itemPrice = Random.Range(0, 99);
        itemName = image.sprite.name;
        item = Manager.ItemManager.GetItemByName(itemName);
        gameObject.name = itemName;
    }

    public void OnClick()
    {
        Debug.Log(itemName+" Price: "+itemPrice);
        View.GetView<ClothShopView>().EquipItem(item);
    }
}
