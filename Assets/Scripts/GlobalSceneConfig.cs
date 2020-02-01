using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSceneConfig : MonoBehaviour
{
    public int currentEnergyPrice;
    public List<int> upgradePrices = new List<int>()
    {
        50, 100, 200, 500
    };
}
