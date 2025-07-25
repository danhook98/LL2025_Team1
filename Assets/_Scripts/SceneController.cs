using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

namespace CannonGame
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highscoreText;

        private int _highscore;

        //references
        //public TMP_Text Highscore;

        //public int Totalhighscore;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //PlayerPrefs.GetInt("highscore");
            _highscore = PlayerPrefs.GetInt("highscore", 0);
            highscoreText.text = $"{_highscore}";
        }

        // Update is called once per frame
        void Update()
        {
            //Highscore.text = Totalhighscore.ToString();
        }

        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
