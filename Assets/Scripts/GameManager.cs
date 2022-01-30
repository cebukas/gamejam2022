using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainFeed;

    private void Start()
    {
        MainFeed.GetComponent<Feed>().StartUpdateFeedRoutine();
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
