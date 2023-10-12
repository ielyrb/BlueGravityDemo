using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static ItemManager ItemManager;

    public static void Setup(ItemManager itemManager)
    {
        ItemManager = itemManager;
    }
}
