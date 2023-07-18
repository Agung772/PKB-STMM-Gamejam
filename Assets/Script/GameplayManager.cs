using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public int score;

    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI speedText;

    public GameObject pauseUI;
    public GameObject pauseButton;

    public bool skill;
    public float cooldownSkill;
    public float cdSkill;
    public Button cdSkillButton;
    public Image cdSkillImage;

    public bool ball;
    public float cooldownBall;
    public float cdBall;
    public Button cdBallButton;
    public Image cdBallImage;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SetSkill();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetBall();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.MainmenuLangsung();
        }

        speedText.text = "Kecepatan : " + Player.instance.speedPlayer.ToString("F1");

        SkillCalculate();
        BallCalculate();

        
    }


    bool pauseBool;
    public void Pause()
    {
        if (!pauseBool)
        {
            pauseBool = true;
            pauseUI.SetActive(true);

            pauseButton.GetComponent<Image>().sprite = pauseButton.GetComponent<Puase>().playButton;

            Time.timeScale = 0;
        }
        else
        {
            pauseBool = false;
            pauseUI.SetActive(false);

            pauseButton.GetComponent<Image>().sprite = pauseButton.GetComponent<Puase>().pauseButton;

            Time.timeScale = 1;
        }

        AudioManager.instance.ButtonClickSFX();
    }

    public void SetScore(int value)
    {
        if (scoreDouble)
        {
            score += value * 2;
        }
        else
        {
            score += value;
        }
        scoreText.text = "Skor : " + score;
    }

    bool setSkill;
    public void SetSkill()
    {
        if (!setSkill)
        {
            setSkill = true;
            if (cdSkill <= 0)
            {
                GameManager.instance.SetCursor("Sihir");
                skill = true;

            }
        }
        else
        {
            setSkill = false;

            GameManager.instance.SetCursor("Biasa");
            skill = false;


        }

        if (cdSkillButton.interactable)
        {
            AudioManager.instance.ButtonClickSFX();
        }

    }

    public void UseSkill()
    {
        skill = false;
        setSkill = false;
        GameManager.instance.SetCursor("Biasa");
        cdSkillButton.interactable = false;
        cdSkill = cooldownSkill;


    }

    void SkillCalculate()
    {
        cdSkill -= Time.deltaTime;
        cdSkill = Mathf.Clamp(cdSkill, 0, cooldownSkill);

        cdSkillImage.fillAmount = cdSkill / cooldownSkill;

        if (cdSkill <= 0)
        {
            cdSkillButton.interactable = true;
        }

        if (skillTakTerbatas)
        {
            cdSkill = 0;
        }
    }

    public void SetBall()
    {
        if (cdBall <= 0)
        {

            if (!ball)
            {
                ball = true;
                cdBall = cooldownBall;
                Player.instance.SetBigPlayer();
                cdBallButton.interactable = false;
            }
            else
            {
                ball = false;
                cdBall = cooldownBall;
                Player.instance.SetSmallPlayer();
                cdBallButton.interactable = false;
            }
            AudioManager.instance.ButtonClickSFX();
        }

    }
    void BallCalculate()
    {
        cdBall -= Time.deltaTime;
        cdBall = Mathf.Clamp(cdBall, 0, cooldownBall);

        cdBallImage.fillAmount = cdBall / cooldownBall;


        if (cdBall <= 0)
        {
            cdBallButton.interactable = true;
        }
    }

    [HideInInspector]
    public bool scoreDouble;
    //powerup
    public void ScoreDouble(Sprite gambarItem)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            ResetItem();
            UIManager.instance.itemImage.gameObject.SetActive(true);
            UIManager.instance.itemImage.sprite = gambarItem;
            scoreDouble = true;
            yield return new WaitForSeconds(10);

            scoreDouble = false;
            UIManager.instance.itemImage.gameObject.SetActive(false);
        }
    }

    [HideInInspector]
    public bool nonEnemy;

    public void NonEnemy(Sprite gambarItem)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            ResetItem();
            UIManager.instance.itemImage.gameObject.SetActive(true);
            UIManager.instance.itemImage.sprite = gambarItem;
            nonEnemy = true;
            yield return new WaitForSeconds(10);

            nonEnemy = false;
            UIManager.instance.itemImage.gameObject.SetActive(false);
        }
    }

    [HideInInspector]
    public bool slideKebalik;
    public void SlideKebalik(Sprite gambarItem)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            ResetItem();
            UIManager.instance.itemImage.gameObject.SetActive(true);
            UIManager.instance.itemImage.sprite = gambarItem;
            slideKebalik = true;
            yield return new WaitForSeconds(10);

            slideKebalik = false;
            UIManager.instance.itemImage.gameObject.SetActive(false);
        }
    }

    [HideInInspector]
    public bool skillTakTerbatas;
    public void SkillTakTerbatas(Sprite gambarItem)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            ResetItem();
            UIManager.instance.itemImage.gameObject.SetActive(true);
            UIManager.instance.itemImage.sprite = gambarItem;
            skillTakTerbatas = true;
            yield return new WaitForSeconds(10);

            skillTakTerbatas = false;
            UIManager.instance.itemImage.gameObject.SetActive(false);
        }
    }

    void ResetItem()
    {
        scoreDouble = false;
        nonEnemy = false;
        slideKebalik = false;
        skillTakTerbatas = false;
    }
}
