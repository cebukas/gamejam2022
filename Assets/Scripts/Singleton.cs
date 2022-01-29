using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Singleton : MonoBehaviour
    {
        void Awake()
        {
            int numberOfinstances = FindObjectsOfType<Singleton>().Length;
            if (numberOfinstances > 1)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
