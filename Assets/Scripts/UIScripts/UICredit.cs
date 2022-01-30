using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICredit : MonoBehaviour
{
    public void onApproveClick()
    {
       FindObjectOfType<AudioManager>().Play("click"); 

        Destroy(this.transform.Find("Buttons").gameObject);

    }
    public void onDisapproveClick()
    {
       FindObjectOfType<AudioManager>().Play("click"); 

       Destroy(this.gameObject);

    }
}
