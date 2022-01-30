using TMPro;
using UnityEngine;
public class UIStats : MonoBehaviour
{
    public TMP_Text crypto, dictator, citizen, foreign;



    public void updateStats(int crypto, int dictator, int citizen, int foreign){
        Debug.Log("UPDATE STATS GOT CALLED LYAT");
        this.crypto.text = crypto.ToString();
        this.dictator.text = dictator.ToString();
        this.citizen.text = citizen.ToString();
        this.foreign.text = foreign.ToString();
    }
}
