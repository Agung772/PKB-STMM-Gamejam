using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Texture2D cursorBiasa;
    public Texture2D cursorGeser;
    public Texture2D cursorSihir;
    private void Awake()
    {
        instance = this;

        QualitySettings.SetQualityLevel(0);
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        SetCursor("Biasa");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SetCursor(string value)
    {
        if (ParticleCursor.instance != null)
        {
            if (value == "Biasa")
            {
                Vector2 cursorHotspot = new Vector2(cursorGeser.width / 5, cursorGeser.height / 5);
                Cursor.SetCursor(cursorBiasa, cursorHotspot, CursorMode.Auto);
                ParticleCursor.instance.active = false;
            }
            else if (value == "Geser")
            {
                Vector2 cursorHotspot = new Vector2(cursorGeser.width / 2, cursorGeser.height / 2);
                Cursor.SetCursor(cursorGeser, cursorHotspot, CursorMode.Auto);
                ParticleCursor.instance.active = false;
            }
            else if (value == "Sihir")
            {
                Vector2 cursorHotspot = new Vector2(cursorGeser.width / 4, cursorGeser.height / 4);
                Cursor.SetCursor(cursorSihir, cursorHotspot, CursorMode.Auto);
                ParticleCursor.instance.active = true;
            }
        }

    }
    //Ex Coroutine
    /*
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(2);
        }
    */
}
