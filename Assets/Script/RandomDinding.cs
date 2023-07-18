using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDinding : MonoBehaviour
{
    public int jarakDinding;
    int jarak;

    public GameObject dindingSlide;
    public GameObject dindingSlide2;
    public GameObject dindingTitiSlide;
    public GameObject dindingHancur;

    private void Start()
    {
        jarak = -40;

        for (int i = 0; i < 6; i++)
        {
            int random = Random.Range(1, (4 + 1));
            GameObject objectTemp = null;
            if (random == 1)
            {
                objectTemp = dindingSlide;
            }
            else if (random == 2)
            {
                objectTemp = dindingSlide2;
            }
            else if (random == 3)
            {
                objectTemp = dindingTitiSlide;
            }
            else if (random == 4)
            {
                objectTemp = dindingHancur;
            }


            GameObject instantiate = Instantiate(objectTemp, transform);

            var pos = instantiate.transform;
            pos.position = new Vector3(pos.position.x + Random.Range(-5, 5), pos.position.y, pos.position.z + jarak);
            jarak += jarakDinding;
        }
    }
}
