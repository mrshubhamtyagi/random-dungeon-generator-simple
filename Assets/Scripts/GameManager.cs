using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    private void Awake()
    {
        if (INSTANCE == null) INSTANCE = this;
        else Destroy(this);
    }

    void Start()
    {

    }

    public static void DebugLog(string _log)
    {
        Debug.Log(_log);
    }
}
