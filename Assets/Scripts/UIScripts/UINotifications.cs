using UnityEngine;
using TMPro;
public class UINotifications : MonoBehaviour
{
    public TMP_Text notificationsTMP; 

    public void updateText(int notificationsAmount)
    {
        notificationsTMP.text = notificationsAmount.ToString();
    }
}
