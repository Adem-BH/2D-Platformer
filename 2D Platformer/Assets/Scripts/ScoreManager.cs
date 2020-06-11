using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI HighestScore;


    public string TextDisplay = "Gold : ";
    public string HighDisplay = "Highest Score Is : ";

    public bool Reset;

    public AudioSource Coin;
    public void ResetHS()
    {
        if (Reset == true)
        {
            PlayerPrefs.SetInt("HighScore", 0);
            Reset = false;
       

        }
    }
    void Start()
    {
        Text.text = TextDisplay + score.ToString();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Coin.Play();
            Destroy(collision.gameObject);
            score++;
            Text.text = TextDisplay + score.ToString();;

            if(score > PlayerPrefs.GetInt("HighScore"))
            {

                PlayerPrefs.SetInt("HighScore", score);


            }

        }
    }

    private void FixedUpdate()
    {
        HighestScore.text = HighDisplay + PlayerPrefs.GetInt("HighScore").ToString();
        ResetHS();

    }

   

}
