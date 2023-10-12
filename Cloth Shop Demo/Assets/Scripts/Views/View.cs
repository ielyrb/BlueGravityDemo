using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    private static List<View> views = new List<View>();

    [SerializeField] List<GameObject> elements;

    public virtual void Awake()
    {
        views.Add(this);
    }

    public virtual void Start()
    {
        if(closeBtn != null) closeBtn.onClick.AddListener(HideView);
    }

    public virtual void ShowView()
    {
        elements.ForEach(x => x.SetActive(true));
    }

    public virtual void HideView()
    {
        elements.ForEach(x => x.SetActive(false));
    }

    public static T GetView<T>() where T: View
    {
        return (T)views.FirstOrDefault(x => x.GetType() == typeof(T));
    }
}
