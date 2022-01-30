using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    public TMP_Text crypto, dictator, citizen, foreign;
    [SerializeField]
    private Sprite spriteUp, spriteDown;
    [SerializeField]
    private Image cryptoIndicator, dictatorIndicator, citizenIndicator, foreignIndicator;

    public void updateStats(int crypto, int dictator, int citizen, int foreign){
        this.crypto.text = string.Format("{0:0}", crypto);
        this.dictator.text = string.Format("{0:0}", dictator);
        this.citizen.text = string.Format("{0:0}", citizen);
        this.foreign.text = string.Format("{0:0}", foreign);
    }

    public void updateIndicator(bool isCryptoUp, bool isDictatorUp, bool isCitizenUp, bool isForeignUp){
        UpdateIndicator(cryptoIndicator, isCryptoUp);
        UpdateIndicator(dictatorIndicator, isDictatorUp);
        UpdateIndicator(citizenIndicator, isCitizenUp);
        UpdateIndicator(foreignIndicator, isForeignUp);
    }

    private void UpdateIndicator(Image image, bool isUp)
    {
        if(isUp)
        {
            image.sprite = spriteUp;
        } else
        {
            image.sprite = spriteDown;
        }
    }
}