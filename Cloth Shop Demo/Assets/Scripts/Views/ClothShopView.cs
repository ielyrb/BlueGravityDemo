using System.Collections;
using UnityEngine;

public class ClothShopView : View
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform itemsContainer;
    [SerializeField] ShopSprite shopSprite;

    public void InitializeShop()
    {
        StartCoroutine(OnInitializeShop());
    }

    IEnumerator OnInitializeShop()
    {
        foreach (Transform child in itemsContainer)
        {
            Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < 30; i++)
        {
            ShopItem item = Instantiate(itemPrefab, itemsContainer).GetComponent<ShopItem>();
            item.Randomize();
        }

        yield return new WaitForSeconds(0.25f);
        ShowView();
    }

    public void EquipItem(ItemSO newItem)
    {
        shopSprite.EquipItem(newItem);
    }
}
