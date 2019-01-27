using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evalFinalWall : MonoBehaviour
{
    public int maxInv;
    private Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        inv = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.itemKeys.Count >= maxInv)
        {
            this.gameObject.SetActive(false);
        }
    }
}
