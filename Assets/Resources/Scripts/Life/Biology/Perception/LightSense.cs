using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSense : MonoBehaviour
{
    [Range(0, 100)]
    public float level = 0f;

    [Range(0, 100)]
    public float sensed = 0f;

    [Range(0, 100)]
    public float efficiency = 0f;

    RaycastHit hit;

    void Update()
    {
        if (
            Physics
                .Raycast(transform.position,
                Vector3.up,
                out hit,
                Mathf.Infinity)
        )
        {
            if (hit.transform.tag == "OceanSurface")
            {
                level = (100f - hit.distance);
                sensed = level * (efficiency / 100f);
            }
            else
            {
                level = 0f;
                sensed = 0f;
            }
        }
    }
}
