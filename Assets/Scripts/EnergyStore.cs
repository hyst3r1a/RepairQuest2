using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStore : MonoBehaviour, IInteractable
{
    public GlobalSceneConfig config;
    public int energyUnits;
    public float rechargeTime;
    public float currentRechargeTime;
    public bool fullMoney;

    public void Interact(Player player)
    {
        Debug.Log("BUYING ENERGY");
        if (currentRechargeTime <= 0)
        {
            if (fullMoney)
            {
                
                int energyToSell = player.money % config.currentEnergyPrice;
                energyToSell = player.money - energyToSell;
                energyToSell = player.money / config.currentEnergyPrice;
                player.money -= energyToSell * config.currentEnergyPrice;
                player.energy += energyToSell;
                currentRechargeTime += rechargeTime;
            }
            else
            {

                if (player.money >= energyUnits * config.currentEnergyPrice)
                {
                    player.money -= energyUnits * config.currentEnergyPrice;
                    player.energy += energyUnits;
                    currentRechargeTime += rechargeTime;
                }
            }

        }

        Debug.Log("DEBUG INTERACTION");
    }


    void Update()
    {
        if(currentRechargeTime > 0)
        {
            currentRechargeTime -= Time.deltaTime;
        }
    }
}
