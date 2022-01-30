using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBribe : MonoBehaviour
{
   public Comment comment;
   public Post post;
   
   public void OnBribeClick()
   {
      FindObjectOfType<AudioManager>().Play("click"); 

      this.transform.Find("Image").gameObject.transform.Find("Buttons").gameObject.SetActive(false);
      
      Interactor.ActivatePerk(PerkEnum.Bribery, comment._uniqueId);
   }
}
