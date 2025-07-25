using UnityEngine;

namespace CannonGame
{
    public class PauseQuit : MonoBehaviour
    {
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
            }
        }


    }
}
