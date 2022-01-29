using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int cryptoKopek, dictatorApproval, foreignAffairs, citizenSupport;

    /*
     * Change our stats by 'change'
     * 'change' can be a negative number as well
     */
    public void UpdateStat(Stats stat, int change)
    {
        switch (stat)
        {
            case Stats.CitizenSupport:
                citizenSupport += change;
                break;
            case Stats.CryptoKopek:
                cryptoKopek += change;
                break;
            case Stats.DictatorApproval:
                dictatorApproval += change;
                break;
            case Stats.ForeignAffairs:
                foreignAffairs += change;
                break;
        }
    }
}
