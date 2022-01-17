using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : MonoBehaviour
{
    PlayerStateManager PSM;

    UI UI;

    void Start()
    {
        PSM = GetComponent<PlayerStateManager>();
        UI = FindObjectOfType<UI>();
    }

    public void StartNewGame()
    {
        PSM.FreshStart();
        UI.Menu.transform.Find("Start Menu").GetComponent<Canvas>().enabled =
            false;
        UI.HUD.enabled = true;
    }
}
