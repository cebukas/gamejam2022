using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

public class LoadGameButton : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        FindObjectOfType<AudioManager>().Play("click"); 
        sceneController.LoadScene(Scene.Game);
    }
}
