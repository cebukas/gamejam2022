using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainFeed;

    // Update is called once per frame
    private void Start()
    {
        MainFeed.GetComponent<Feed>().StartUpdateFeedRoutine();
    }

    private void GameCycle()
    {
        // NOTE: Use coroutines for time calculations
    }
}
