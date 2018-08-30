using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RankType { Weak, Strong, Deadly, Brutal, Hardcore, Insane, Anchorish };

public class Player : ScriptableObject
{ 
    public string Name = "Sir Space Anchor";
    public int Health = 100;
    public int HealthMax = 100;
    public int Energy = 100;
    public int EnergyMax = 100;
    public RankType damage = RankType.Weak;
    public bool isDead = false;

    public void TakeDamage(float damage)
    {

        Health -= Mathf.RoundToInt(damage);
    }

    public void HealDamage(float damage)
    {
        //Health += damage;
        Health += Mathf.RoundToInt(damage);
    }

    public int Damage
    {
        get
        {
            switch (damage)
            {
                case RankType.Weak:
                default:
                    return 1;
                case RankType.Strong:
                    return 2;
                case RankType.Deadly:
                    return 4;
                case RankType.Brutal:
                    return 8;
                case RankType.Hardcore:
                    return 24;
                case RankType.Insane:
                    return 32;
                case RankType.Anchorish:
                    return 50;
            }
        }
    }
}
