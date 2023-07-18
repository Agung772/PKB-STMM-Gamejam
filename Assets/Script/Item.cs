using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite[] item;
    public SpriteRenderer spriteRenderer;
    int random;

    public ParticleSystem particle;

    private void Start()
    {
        random = (int)Random.Range(0f, item.Length);
        spriteRenderer.sprite = item[random];


        int randomDestroy = Random.Range(0, 3);
        if (randomDestroy == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            var gameplayM = GameplayManager.instance;
            //Double score
            if (random == 0)
            {
                if (!gameplayM.scoreDouble && !gameplayM.nonEnemy && !gameplayM.slideKebalik && !gameplayM.skillTakTerbatas)
                {
                    GameplayManager.instance.ScoreDouble(item[0]);
                }
                else
                {
                    UIManager.instance.SpawnNotif("Tidak dapat mengambil item jika ada item yang aktif");
                }

            }
            //hilngkan musuh
            else if (random == 1)
            {
                if (!gameplayM.scoreDouble && !gameplayM.nonEnemy && !gameplayM.slideKebalik && !gameplayM.skillTakTerbatas)
                {
                    GameplayManager.instance.NonEnemy(item[1]);
                }
                else
                {
                    UIManager.instance.SpawnNotif("Tidak dapat mengambil item jika ada item yang aktif");
                }

            }
            //geser dinding jadi kebalik
            else if (random == 2)
            {
                if (!gameplayM.scoreDouble && !gameplayM.nonEnemy && !gameplayM.slideKebalik && !gameplayM.skillTakTerbatas)
                {
                    GameplayManager.instance.SlideKebalik(item[2]);
                }
                else
                {
                    UIManager.instance.SpawnNotif("Tidak dapat mengambil item jika ada item yang aktif");
                }

            }
            //skill tak terbatas
            else if (random == 3)
            {

                if (!gameplayM.scoreDouble && !gameplayM.nonEnemy && !gameplayM.slideKebalik && !gameplayM.skillTakTerbatas)
                {
                    GameplayManager.instance.SkillTakTerbatas(item[3]);
                }
                else
                {
                    UIManager.instance.SpawnNotif("Tidak dapat mengambil item jika ada item yang aktif");
                }
            }
            else
            {
                Destroy(gameObject);
            }

            Instantiate(particle, transform.position, transform.rotation);
            AudioManager.instance.ButtonClickSFX();
            Destroy(gameObject);
        }
    }
}
