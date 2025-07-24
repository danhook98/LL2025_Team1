using CannonGame.EventSystem;
using DG.Tweening;
using JetBrains.Annotations;
using System;
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
        public int Totalscore = 0;

        public int Totalhighscore;

        //shop checks
        public bool Shopbusy = false;
        public bool Shopopen = false;

        [SerializeField] int[] turretPrices;
        [SerializeField] TextMeshProUGUI[] priceTexts;
        [SerializeField] IntEvent spawnTurretEvent;
        [SerializeField] Tween currentTween;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ///loads players highscore on start
            Totalhighscore = PlayerPrefs.GetInt("highscore");
            for (int i = 0; i < turretPrices.Length; i++)
			{
				priceTexts[i].text = "Score :" + turretPrices[i].ToString();
			}
		}

		// Update is called once per frame
        void Update()
        {
            ///both scores are visualised to player through text
            Score.text = Totalscore.ToString();

            Highscore.text = Totalhighscore.ToString();

            if (Shopopen && Shop.transform.localPosition.x != -200)
            {
				if (currentTween != null && currentTween.IsPlaying()) return;
				currentTween = Shop.transform.DOLocalMoveX(-200f, 1f);
			} else if (!Shopopen && Shop.transform.localPosition.x != -400)
            {
                if(currentTween != null && currentTween.IsPlaying()) return;
				currentTween = Shop.transform.DOLocalMoveX(-400f, 0.5f);
			}

            ///sets players highscore as current score if its higher then the current highscore
            if (Totalscore > Totalhighscore) PlayerPrefs.SetInt("highscore", Totalscore);
        }

        //changes score for testing
        public void IncreaseScore(int score)
        {
            Totalscore += score;
        }
        public void DecreaseScore(int score)
        {
            Totalscore -= score;
        }
        public void ResetScore()
        {
            Totalscore = 0;
        }
        public void ResetHighscore()
        {
            Totalhighscore = 0;
            //once reset won't remember its previous highscore
            PlayerPrefs.SetInt("highscore", 0);
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
            if (!Shopopen)
            {
                Shopopen = true;
                Debug.Log("welcome to shop");
                currentTween.Kill();
                currentTween = null;
                //first number is distance you want moved (not the actual position) second is how long it takes to move that much (1 is a second 60 is a minute)
                //DOMoveX uses global then local, use DOLocalMoveX if you want specific movement
                //StartCoroutine(ShopTransition());
            }

        }
        public void Closeshop()
        {
            if (Shopopen)
            {
                Shopopen = false;
                Debug.Log("Bye bye");
				currentTween.Kill();
				currentTween = null;
				//StartCoroutine(ShopTransition());
			}
        }

        //IEnumerator ShopTransition()
        //{
        //    Shopbusy = true;
        //    yield return new WaitForSeconds(0.2f);
        //    Shopbusy = false;
        //    if (Shopopen)
        //    {
        //        yield return new WaitForSeconds(0.5f);
        //        if (Shopopen) Shopopen = false;
        //    }
        //    else if (!Shopopen)
        //    {
        //        yield return new WaitForSeconds(1f);
        //        if (!Shopopen) Shopopen = true;
        //    }
        //}

        public void BuyItem1()
        {
            if (Totalscore >= 5)
            {
                Totalscore -= 5;
            }
        }
        public void BuyItem2()
        {
            if (Totalscore >= 10)
            {
                Totalscore -= 10;
            }
        }
        public void BuyItem3()
        {
            if (Totalscore >= 15)
            {
                Totalscore -= 15;
            }
        }

        public void BuyTurret(int index)
        {
            if(Totalscore >= turretPrices[index])
            {
                Totalscore -= turretPrices[index];
                turretPrices[index] = Mathf.FloorToInt(turretPrices[index] * 1.5f);
                priceTexts[index].text = turretPrices[index].ToString();
                spawnTurretEvent.Invoke(index);
            }
        }
    }
}
