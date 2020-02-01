using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IInteractable
{
    public int partsNeeded;
    public int currentParts;
    public int energyNeeded;
    public int currentEnergy;
    public GameObject mat;

    public void Interact(Player player)
    {
      if(currentParts < partsNeeded && player.parts > 0)
        {
            currentParts += 1;
            player.parts -= 1;
        }
        else
        {
            if (currentParts == partsNeeded && currentEnergy < energyNeeded && player.energy > 0)
            {
                currentEnergy += 1;
                player.energy -= 1;
                float cE = currentEnergy, eN = energyNeeded;
                MaterialPropertyBlock props = new MaterialPropertyBlock();
                
                Debug.Log((1f / 100f) * currentEnergy / (energyNeeded / 100f));
                props.SetColor("_EmissionColor", new Color(190, 170, 0) * ((1f / 1000f) * currentEnergy / (energyNeeded / 100f))/7.5f);
                mat.GetComponent<Renderer>().SetPropertyBlock(props);
            }
        }
    }

}
