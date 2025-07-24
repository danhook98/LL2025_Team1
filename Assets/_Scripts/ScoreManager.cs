using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace CannonGame
{
    public class ScoreManager : MonoBehaviour
    {
        //gives access to the UI text
        public TMP_Text Score;
        public TMP_Text Highscore;

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
            //once reset won't remember its previous highscore
            PlayerPrefs.SetFloat("highscore", 0);
        }
    }
}
