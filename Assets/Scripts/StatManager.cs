using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stats { cryptoKopek, dictatorApproval, forreignAffairs, citizenSupport }

public class StatManager : MonoBehaviour
{
    public int cryptoKopek, dictatorApproval, forreignAffairs, citizenSupport;

    public void UpdateStat(Stats stat, int change)
    {
        if (stat == Stats.cryptoKopek)
            cryptoKopek += change;
        if (stat == Stats.dictatorApproval)
            dictatorApproval += change;
        if (stat == Stats.forreignAffairs)
            forreignAffairs += change;
        if (stat == Stats.citizenSupport)
            citizenSupport += change;
    }
}


