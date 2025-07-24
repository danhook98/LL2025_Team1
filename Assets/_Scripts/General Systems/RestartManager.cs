using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace CannonGame
{
    public class RestartManager : MonoBehaviour
    {
        bool restarterEnabled;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
			GetComponent<TextMeshProUGUI>().alpha = 0;
		}

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && restarterEnabled)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void EnableRestartManager()
        {
			restarterEnabled = true;
            GetComponent<TextMeshProUGUI>().alpha = 1;
        }
    }
}
