using Newtonsoft.Json;
using UnityEngine;

public class ShopSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer face;
    [SerializeField] SpriteRenderer hood;
    [SerializeField] SpriteRenderer wristL;
    [SerializeField] SpriteRenderer elbowL;
    [SerializeField] SpriteRenderer shoulderL;
    [SerializeField] SpriteRenderer wristR;
    [SerializeField] SpriteRenderer elbowR;
    [SerializeField] SpriteRenderer shoulderR;
    [SerializeField] SpriteRenderer torso;
    [SerializeField] SpriteRenderer bootL;
    [SerializeField] SpriteRenderer legL;
    [SerializeField] SpriteRenderer bootR;
    [SerializeField] SpriteRenderer legR;
    [SerializeField] SpriteRenderer pelvis;

    public void EquipItem(ItemSO item)
    {
        Debug.Log(JsonConvert.SerializeObject(item));
        switch(item.Type)
        {
            case EquipmentType.Armor:
                torso.sprite = item.Sprite[0];
                shoulderL.sprite = item.Sprite[1];
                shoulderR.sprite = item.Sprite[2];
                break;

            case EquipmentType.Boots:
                pelvis.sprite = item.Sprite[0];
                legL.sprite = item.Sprite[1];
                legR.sprite = item.Sprite[2];
                bootL.sprite = item.Sprite[3];
                bootR.sprite = item.Sprite[4];
                break;

            case EquipmentType.Helm:
                hood.sprite = item.Sprite[0];
                face.sprite = item.Sprite[1];
                break;

            case EquipmentType.Gloves:
                elbowL.sprite = item.Sprite[0];
                elbowR.sprite = item.Sprite[1];
                wristL.sprite = item.Sprite[2];
                wristR.sprite = item.Sprite[3];
                break;

        }
    }
}
