using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject FinalWallToRemove;

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        if (FinalWallToRemove != null)
            FinalWallToRemove.SetActive(true);
    }

    public void OpenFinalRoom()
    {
        FinalWallToRemove.SetActive(false);
    }
}
