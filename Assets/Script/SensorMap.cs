using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorMap : MonoBehaviour
{
    bool use;
    private void Update()
    {
        if (use) return;
        if (transform.position.z <= Player.instance.transform.position.z)
        {
            use = true;
            SpawnMap.instance.SetMap();
        }
    }
}
