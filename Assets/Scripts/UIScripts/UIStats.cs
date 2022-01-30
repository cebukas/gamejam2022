using TMPro;
using UnityEngine;
public class UIStats : MonoBehaviour
{
    public TMP_Text crypto, dictator, citizen, foreign;



    public void updateStats(int crypto, int dictator, int citizen, int foreign){
        this.crypto.text = string.Format("{0:0}", crypto);
        this.dictator.text = string.Format("{0:0}", dictator);
        this.citizen.text = string.Format("{0:0}", citizen);
        this.foreign.text = string.Format("{0:0}", foreign);
    }
}