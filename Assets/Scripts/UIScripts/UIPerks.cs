using System;
using UnityEngine;

namespace UIScripts
{
    public class UIPerks : MonoBehaviour
    {
        public GameObject SwapButton;
        public GameObject LoveButton;
        public GameObject PauseButton;
        public GameObject CashButton;

        public GameObject Statman;
        
        private void Start()
        {
            SwapButton.gameObject.SetActive(false);
            LoveButton.gameObject.SetActive(false);
            PauseButton.gameObject.SetActive(false);
            CashButton.gameObject.SetActive(false);

            Statman = FindObjectOfType<StatManager>().gameObject;
        }

        private void Update()
        {
            if (Statman.GetComponent<StatManager>().GetPerkStatus(PerkEnum.Bribery))
            {
                CashButton.gameObject.SetActive(true);
            }
            
            if (Statman.GetComponent<StatManager>().GetPerkStatus(PerkEnum.Embrace))
            {
                LoveButton.gameObject.SetActive(true);
            }
            
            if (Statman.GetComponent<StatManager>().GetPerkStatus(PerkEnum.Reshuffle))
            {
                SwapButton.gameObject.SetActive(true);
            }
            
            if (Statman.GetComponent<StatManager>().GetPerkStatus(PerkEnum.Wait))
            {
                PauseButton.gameObject.SetActive(true);
            }
        }
    }
}