using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DindingSlide : MonoBehaviour
{
    public int direction = 1;
    public Transform dindingGerak;
    Outline outline;
    public DindingSlide dindingSebalah;
    public DindingSlide dindingSebalah2;

    private void OnMouseEnter()
    {
        if (!GameplayManager.instance.skill)
        {
            GameManager.instance.SetCursor("Geser");
        }



    }
    private void OnMouseDown()
    {

        //if (outline == null) outline = GetComponent<Outline>();

        //outline.enabled = true;
        if (dindingSebalah != null)
        {
            //dindingSebalah.gameObject.AddComponent<Outline>();
            //dindingSebalah.GetComponent<Outline>().enabled = true;
        }

        moveX = dindingGerak.position.x;
    }


    public float moveX;
    private void OnMouseDrag()
    {
        if (GameplayManager.instance.slideKebalik)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        if (Input.GetMouseButton(0) && !GameplayManager.instance.skill)
        {
            float mouseX = Input.GetAxis("Mouse X") * direction * 30 * Time.deltaTime;

            moveX += mouseX;

            if (dindingSebalah != null) dindingSebalah.moveX = moveX;
            if (dindingSebalah2 != null) dindingSebalah2.moveX = moveX;

            dindingGerak.position = new Vector3(moveX, dindingGerak.position.y, dindingGerak.position.z);

            if (moveX > 20)
            {
                moveX = 20;
            }
            if (moveX < -20)
            {
                moveX = -20;
            }

        }
    }

    private void OnMouseExit()
    {
        if (!GameplayManager.instance.skill)
        {
            GameManager.instance.SetCursor("Biasa");
        }

    }

    private void OnMouseUp()
    {
        //outline.enabled = false;

        if (dindingSebalah != null)
        {
            //dindingSebalah.GetComponent<Outline>().enabled = false;
        }
    }
}
