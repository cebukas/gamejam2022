using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainFeed;

    private void Start()
    {
        MainFeed.GetComponent<Feed>().StartUpdateFeedRoutine();
    }
}
