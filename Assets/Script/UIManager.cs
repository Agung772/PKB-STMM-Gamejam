using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public enum Scene
    {
        mainmenu,
        gameplay
    }

    public Scene scene;

    public Animator transisiAnimator;

    public GameObject mainmenuUI;
    public GameObject gameplayUI;
    public GameObject settingUI;
    public GameObject loseUI;

    [SerializeField]
    TMP_Dropdown resolutionsDD;
    [SerializeField]
    Toggle fullscreenToggle;
    Resolution[] resolutions;

    public TextMeshProUGUI highScoreText;

    public Image itemImage;

    public Transform spawnNotifText;
    public GameObject notifText;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        //Scene
        if (scene == Scene.mainmenu)
        {
            mainmenuUI.SetActive(true);
            gameplayUI.SetActive(false);

            TransisiScene("Exit");

            highScoreText.text = GameSave.instance.highScore + "";

            GameManager.instance.SetCursor("Biasa");
        }
        else if (scene == Scene.gameplay)
        {
            mainmenuUI.SetActive(false);
            gameplayUI.SetActive(true);

            TransisiScene("Exit");
        }


        //Screen
        resolutions = Screen.resolutions;
        resolutionsDD.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (i > 9)
            {
                string resuliton = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(resuliton);
                print(i);
            }


        }
        resolutionsDD.AddOptions(options);
        resolutionsDD.value = (int)GameSave.instance.resolutionValue;
        resolutionsDD.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;


    }
    private void Update()
    {
        if (scene == Scene.mainmenu)
        {
            GameManager.instance.SetCursor("Biasa");
        }
    }
    public void SetFullscreen(bool value)
    {
        Screen.fullScreen = value;

    }
    public void SetResolution(int value)
    {
        Resolution resolution = resolutions[value + 10];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        print(resolution);
        GameSave.instance.SaveResolution(value);

    }

    public void TransisiScene(string value)
    {
        if (value == "Start")
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.SetTrigger("Start");
        }
        else
        {
            transisiAnimator.gameObject.SetActive(true);
            transisiAnimator.SetTrigger("Exit");
        }
    }

    public void StartGame()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            TransisiScene("Start");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Gameplay");
        }

        AudioManager.instance.ButtonClickSFX();
    }
    public void ExitGame()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            TransisiScene("Start");
            yield return new WaitForSeconds(2);
            Application.Quit();
        }

        AudioManager.instance.ButtonClickSFX();
    }

    public void RestratGame()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            TransisiScene("Start");
            loseUI.GetComponent<Animator>().SetBool("Start", false);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Gameplay");
        }

        AudioManager.instance.ButtonClickSFX();
    }
    public void MainmenuLangsung()
    {
        Time.timeScale = 1;
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {

            TransisiScene("Start");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Mainmenu");
        }

        AudioManager.instance.ButtonClickSFX();
    }
    public void Mainmenu()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            TransisiScene("Start");
            loseUI.GetComponent<Animator>().SetBool("Start", false);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Mainmenu");
        }

        AudioManager.instance.ButtonClickSFX();
    }
    public void SetMainmenuUI()
    {
        FalseUI();

        mainmenuUI.SetActive(true);
    }
    public void SetGameplayUI()
    {
        FalseUI();

        gameplayUI.SetActive(true);
    }

    public void SetSettingUI(bool value)
    {
        if (!value)
        {
            settingUI.GetComponent<Animator>().SetBool("Start", false);
        }
        else
        {
            settingUI.GetComponent<Animator>().SetBool("Start", true);
        }

        AudioManager.instance.ButtonClickSFX();
    }

    public void LoseConditionUI(int value)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(2);
            TransisiScene("Start");
            yield return new WaitForSeconds(2);
            loseUI.SetActive(true);
            loseUI.GetComponent<LoseUI>().SetScore(value);
        }

        AudioManager.instance.LoseSFX();
    }

    void FalseUI()
    {
        mainmenuUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void SpawnNotif(string value)
    {
        GameObject temp = Instantiate(notifText, spawnNotifText);
        temp.GetComponent<TextMeshProUGUI>().text = value;
    }

    public Animator panduanAnimator;
    bool panduan;
    public void PanduanUI()
    {
        if (!panduan)
        {
            panduan = true;
            panduanAnimator.SetBool("Start", true);
        }
        else
        {
            panduan = false;
            panduanAnimator.SetBool("Start", false);
        }

        AudioManager.instance.ButtonClickSFX();
    }
}
