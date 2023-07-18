using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public static SpawnMap instance;

    public GameObject dindingSpawn;
    public int jarakMap;
    int jarak;
    int countMap;

    private void Awake()
    {
        instance = this;
    }

    public void SetMap()
    {
        GameObject mapTemp = Instantiate(dindingSpawn, transform);
        jarak += jarakMap;

        mapTemp.transform.position = new Vector3 (transform.position.x, transform.position.y, jarak);

        countMap++;
        if (countMap > 1)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
