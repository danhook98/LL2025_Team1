using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System.Collections;

namespace CannonGame
{
    public class UIScoreTest : MonoBehaviour
    {
        public GameObject Poweruptxt;
        public GameObject Getpoweruptxt;

        public TMP_Text Score;
        public TMP_Text Highscore;
        public TMP_Text PowerupNameText;
        public TMP_Text GainedPowerupText;


        public float Totalscore = 0f;

        public float Totalhighscore;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ///loads players highscore on start
            Totalhighscore = PlayerPrefs.GetFloat("highscore");
        }

        // Update is called once per frame
        void Update()
        {
            ///both scores are visualised to player through text
            Score.text = Totalscore.ToString();

            Highscore.text = Totalhighscore.ToString();


            ///sets players highscore as current score (will make it only update on a higher score then current highscore later)
            PlayerPrefs.SetFloat("highscore", Totalscore);
        }

        //changes score for testing
        public void IncreaseScore()
        {
            Totalscore += 1f;
        }
        public void DecreaseScore()
        {
            Totalscore -= 1f;
        }
        public void ResetScore()
        {
            Totalscore = 0f;
        }

        //sorting out a base way to tell the player they collected a powerup if we go random powerup spawn for this
        public void PowerupGet()
        {
            PowerupNameText.text = "Splitshot";
            Poweruptxt.SetActive(true);
            Getpoweruptxt.SetActive(true);
            //use coroutines to hide text after a duration of being active
            //StartCoroutine(HidePowerup(5f));
        }


    }
}
