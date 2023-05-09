using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace RN.WIA.Menu
{
    public class Menu : MonoBehaviour
    {//handles menu functions
       public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       public void QuitGame()
        {
            Application.Quit();
        }
    }
}

