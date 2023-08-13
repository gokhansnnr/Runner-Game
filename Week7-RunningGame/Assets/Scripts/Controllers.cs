using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Controllers : MonoBehaviour
{
    public int score;
    public int left;
    public int point;
    private float timer;
    private int highScore;
    private string nickName;
    private float bestTime;

    public TMP_Text leftText;
    public TMP_Text scoreText;
    public TMP_Text loseScoreText;
    public TMP_Text loseTimeText;
    public TMP_Text finScoreText;
    public TMP_Text finTimeText;
    public TMP_Text timeText;
    public TMP_Text loseBestField;
    public TMP_Text winBestField;
    public TMP_Text nickField;

    public bool timeControls;
    public bool isFinish;

    public GameObject overPanel;
    public GameObject finishPanel;
    public GameObject gamePanel;
    public GameObject block;


    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        bestTime = PlayerPrefs.GetFloat("bestTime", 999999f);
        loseBestField.text = "BEST: " + PlayerPrefs.GetString("nickName", "Empty") + " - " + PlayerPrefs.GetInt("highScore", 0) + " - " + PlayerPrefs.GetFloat("bestTime", 0f);
        winBestField.text = "BEST: " + PlayerPrefs.GetString("nickName", "Empty") + " - " + PlayerPrefs.GetInt("highScore", 0) + " - " + PlayerPrefs.GetFloat("bestTime", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        leftText.text = "Left: " + left;
        scoreText.text = "Score: " + score;
    }

    private void FixedUpdate()
    {
        if(left == 0) //Can Biterse
        {
            _animator.SetBool("isDie", true);
            overPanel.SetActive(true);
            gamePanel.SetActive(false);
            block.SetActive(true);
            timeControls = false;
            loseScoreText.text = "SCORE: " + score;
            loseTimeText.text = "TIME: " + timer;
        }

        if (isFinish == true)
        {
            gamePanel.SetActive(false);
            finishPanel.SetActive(true);
            block.SetActive(true);
            timeControls = false;
            finScoreText.text = "SCORE: " + score;
            finTimeText.text = "TIME: " + timer;
        }

        if(timeControls == true) //Süre Baþlamasý
        {
            timer += 1 * Time.fixedDeltaTime; //Zamaný hýzlandýrmak için 1 çarpanýný deðiþtir.
            timeText.text = "Time: " + timer;
        }

    }

    public void newGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void highScoreFunc()
    {
        if (score >= highScore & timer <= bestTime)
        {
                PlayerPrefs.SetInt("highScore", score);
                PlayerPrefs.SetFloat("bestTime", timer);
                PlayerPrefs.SetString("nickName", nickName);       
        }
    }

    public void sendButton()
    {
        nickName = nickField.text;
        highScoreFunc();
    }

}
