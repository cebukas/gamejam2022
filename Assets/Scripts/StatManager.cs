using System;
using UnityEngine;

[Flags]
public enum PerkEnum
{
    Bribery = 1 << 0, // Crypto based perk; Pay money to remove post you dont like without any negative effects
    Wait = 1 << 1, // Dictator based perk; Temporary: add a new slot to the pending post list
    Reshuffle = 1 << 2, // Foreign affairs perk; Force new post to appear?
    Embrace = 1 << 3, // Citizen perk; double the benefits from posts
    //TODO: 
}

public class StatManager : MonoBehaviour
{
    public int cryptoKopek, dictatorApproval, foreignAffairs, citizenSupport;

    public int PerkStatus = 0;


    private void Start()
    {
        cryptoKopek = 50;
        dictatorApproval = 50;
        citizenSupport = 50;
        foreignAffairs = 50;
    }

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

        CheckForPerks();
    }

    // returns true if specific perk is available
    public bool GetPerkStatus(PerkEnum perkEnum)
    {
        return (PerkStatus & (int)perkEnum) == (int)perkEnum;
    }
    
    private void CheckForPerks()
    {
        if (cryptoKopek >= 100)
        {
            PerkStatus |= (int)PerkEnum.Bribery;
        }

        if (dictatorApproval >= 100)
        {
            PerkStatus |= (int) PerkEnum.Wait;
        }

        if (foreignAffairs >= 100)
        {
            PerkStatus |= (int) PerkEnum.Reshuffle;
        }

        if (citizenSupport >= 100)
        {
            PerkStatus |= (int) PerkEnum.Embrace;
        }
    }
    
    // returns false if any of stats is 0, this means game over
    public bool CheckStatStatus()
    {
        return citizenSupport > 0 && cryptoKopek > 0 && foreignAffairs > 0 && dictatorApproval > 0;
    }
}
