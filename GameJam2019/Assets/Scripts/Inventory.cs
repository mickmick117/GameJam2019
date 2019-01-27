using UnityEngine;
using System.Collections;
using System.Collections.Generic;   

public class Inventory : MonoBehaviour
{

    public static Inventory instance = null;
    public List<string> items = new List<string>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void addItem(string tag)
    {
        if (!items.Contains(tag))
            items.Add(tag);
    }
}
