using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Feed MainFeed { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        MainFeed = gameObject.AddComponent<Feed>();
    }

    // Update is called once per frame
    void Update()
    {
        MainFeed.UpdateFeed();
    }

    private void GameCycle()
    {
        // NOTE: Use coroutines for time calculations
    }
}
