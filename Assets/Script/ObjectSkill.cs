using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSkill : MonoBehaviour
{
    public Animator animator;

    private void OnMouseDown()
    {
        if (GameplayManager.instance.skill)
        {
            AudioManager.instance.SihirSFX();


            if (animator == null)
            {
                animator = gameObject.GetComponent<Animator>();
            }
            animator.SetTrigger("Start");
            GameplayManager.instance.UseSkill();
            Destroy(animator.gameObject, 2);
        }
    }
}
