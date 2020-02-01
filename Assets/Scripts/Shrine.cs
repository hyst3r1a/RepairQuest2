using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour, IInteractable
{
    public Upgrades upgrade = Upgrades.Damage;
    public GlobalSceneConfig config;
    public float rechargeTime = 5f;
    public float currentRechargeTime;

    void Update()
    {
        if (currentRechargeTime > 0)
        {
            currentRechargeTime -= Time.deltaTime;
        }
    }

    public void Interact(Player player)
    {
        if (currentRechargeTime <= 0)
        {
            switch (upgrade)
            {
                case Upgrades.Damage:
                    if (player.upDamageLvl < 4)
                    {
                        if (config.upgradePrices[player.upDamageLvl] <= player.money)
                        {
                            
                            player.money -= config.upgradePrices[player.upDamageLvl];
                            player.upDamageLvl += 1;
                            currentRechargeTime += rechargeTime;
                            Debug.Log("Damage Upgraded");
                        }
                    }
                    break;
                case Upgrades.Health:
                    if (player.upMaxHP < 4)
                    {
                        if (config.upgradePrices[player.upMaxHP] <= player.money)
                        {
                            
                            player.money -= config.upgradePrices[player.upMaxHP];
                            player.upMaxHP += 1;
                            currentRechargeTime += rechargeTime;
                        }
                    }
                    break;
                case Upgrades.Speed:
                    if (player.upSpeedLvl < 4)
                    {
                        if (config.upgradePrices[player.upSpeedLvl] <= player.money)
                        {
                            
                            player.money -= config.upgradePrices[player.upSpeedLvl];
                            player.upSpeedLvl += 1;
                            currentRechargeTime += rechargeTime;
                        }
                    }
                    break;
                case Upgrades.Energy:
                    if (player.upMaxEnergy < 4)
                    {
                        if (config.upgradePrices[player.upMaxEnergy] <= player.money)
                        {
                            
                            player.money -= config.upgradePrices[player.upMaxEnergy];
                            player.upMaxEnergy += 1;
                            currentRechargeTime += rechargeTime;
                        }
                    }
                    break;
            }
        }
    }
}
