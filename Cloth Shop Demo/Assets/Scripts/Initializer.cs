using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] ItemManager itemManager;
    void Awake()
    {
        Manager.Setup(itemManager);
    }
}
