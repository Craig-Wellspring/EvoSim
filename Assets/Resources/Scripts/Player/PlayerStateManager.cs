using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;

    PlayerSettings PlayerSettings;

    CameraManager CamMan;

    void Start()
    {
        PlayerSettings = FindObjectOfType<PlayerSettings>();
        CamMan = GetComponent<CameraManager>();
    }

    public void FreshStart()
    {
        PlayerObject = FindObjectOfType<LifeGeneration>().GenerateSpawn();
        PlayerObject.name = PlayerSettings.PlayerName;
        CamMan.FocusCamera(PlayerObject.transform, 20);
    }
}
