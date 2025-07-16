using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

namespace CannonGame
{
    public class UIScoreTest : MonoBehaviour
    {
        //needed to disable powerup text to hide it
        public GameObject Poweruptxt;
        public GameObject Getpoweruptxt;
        
        //gives access to the UI text
        public TMP_Text Score;
        public TMP_Text Highscore;
        public TMP_Text PowerupNameText;
        public TMP_Text GainedPowerupText;

        //keeps check on the scores
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

            ///sets players highscore as current score if its higher then the current highscore
            if (Totalscore > Totalhighscore) PlayerPrefs.SetFloat("highscore", Totalscore);
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
        public void ResetHighscore()
        {
            Totalhighscore = 0f;
            //once resetted won't remember its previous highscore
            PlayerPrefs.SetFloat("highscore", 0);
        }

        //sorting out a base to tell the player they collected a powerup if we go random powerup spawn for this
        public void PowerupGet()
        {
            //tests if it can change text while disabled and will be made to say the name of the specific powerup you collect
            PowerupNameText.text = "Splitshot";
            Poweruptxt.SetActive(true);
            Getpoweruptxt.SetActive(true);
            StartCoroutine(Hidepowerup());
        }

        //hides powerup text after time
        IEnumerator Hidepowerup()
        {
            yield return new WaitForSeconds(5f);
            Poweruptxt.SetActive(false);
            Getpoweruptxt.SetActive(false);
        }
    }
}
