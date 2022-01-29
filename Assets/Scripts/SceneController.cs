using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public enum Scene
    {
        Intro,
        Game,
        GameWon,
        GameOver,
    }

    public class SceneController : MonoBehaviour
    {
        public void LoadScene(Scene scene)
        {
            SceneManager.LoadScene((int)scene);
        }

        //FOR BUTTONS ON CLICK
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

