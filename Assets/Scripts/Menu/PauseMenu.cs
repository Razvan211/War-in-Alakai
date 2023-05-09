using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RN.WIA.Menu
{//handles pause menu functions
    public class PauseMenu : MonoBehaviour
    {
        public static bool gameIsPaused = false;

        private string sceneMenu = "Menu";

        public GameObject pauseMenuUI;
        public GameObject gameUI;
      
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            gameUI.SetActive(true);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneMenu);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }

}
