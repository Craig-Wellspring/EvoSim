using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLevel : MonoBehaviour
{
    public float level = 0f;
    void Update()
    {
        level = transform.root.position.y / 100;
    }
}
