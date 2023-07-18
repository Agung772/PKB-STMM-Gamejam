using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DindingHancur : MonoBehaviour
{
    public ParticleSystem particleHancur;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() && Player.instance.bigPlayer)
        {
            Instantiate(particleHancur, transform.position, transform.rotation);
            Destroy(gameObject);

            AudioManager.instance.TembokHancurSFX();
        }
    }
}
