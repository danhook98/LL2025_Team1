using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CannonGame
{
    public class UIScoreTest : MonoBehaviour
    {
        //needed to disable powerup text to hide it
        public GameObject Poweruptxt;
        public GameObject Getpoweruptxt;
        public GameObject Shop;

        //gives access to the UI text
        public TMP_Text Score;
        public TMP_Text Highscore;
        public TMP_Text PowerupNameText;
        public TMP_Text GainedPowerupText;

        //keeps check on the scores
        public float Totalscore = 0f;

        public float Totalhighscore;

        //shop checks
        public bool Shopopen = false;

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
            //once reset won't remember its previous highscore
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

        ///Attempting to make a base for the shop using the same script below
        public void Openshop()
        {
            //if (!Shopopen)
            {
                Debug.Log("welcome to shop");
                //first number is distance you want moved (not the actual position) second is how long it takes to move that much (1 is a second 60 is a minute)
                //DOMoveX uses global then local, use DOLocalMoveX if you want specific movement
                Shop.transform.DOLocalMoveX(-200f, 1f);
                //StartCoroutine(ShopTransition());
            }

        }
        public void Closeshop()
        {
            //if (Shopopen)
            {
                Debug.Log("Bye bye");
                Shop.transform.DOLocalMoveX(-400f, 0.5f);
                //StartCoroutine(ShopTransition());
            }
        }

        //IEnumerator ShopTransition()
        //{
            //if (Shopopen)
            //{
            //    yield return new WaitForSeconds(0.5f);
            //    if (Shopopen) Shopopen = false;
            //}
            //else (!Shopopen)
            //{
            //    yield return new WaitForSeconds(1f);
            //    if (!Shopopen) Shopopen = true;
            //}
        //}
    }
}
