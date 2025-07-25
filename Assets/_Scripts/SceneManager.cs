using TMPro;
using UnityEngine;

namespace CannonGame
{
    public class SceneManager : MonoBehaviour
    {
        //references
        //public TMP_Text Highscore;

        //public int Totalhighscore;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //PlayerPrefs.GetInt("highscore");
        }

        // Update is called once per frame
        void Update()
        {
            //Highscore.text = Totalhighscore.ToString();
        }

        public void Play()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("UI_TestScene");
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
