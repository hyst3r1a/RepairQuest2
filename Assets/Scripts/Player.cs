using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public int energy;// { get; set; }
    public int health;// { get; set; }
    public int money;//{ get; set; }
    public int parts;// { get; set; }
    public float shootingInterval = 0.3f;
    public float timeToNextShot = 0.0f;
    public float laserActiveTime = 0.1f;
    public float laserActiveFor = 0.0f;
    public IInteractable currentInteractable;
    public bool canInteract;// { get; set; } = false;

    //UPGRADE LEVELS
    public int upSpeedLvl { get; set; } = 0;
    public int upDamageLvl { get; set; } = 0;
    public int upMaxHP { get; set; }  = 0;
    public int upMaxEnergy { get; set; }  = 0;

    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            currentInteractable = other.gameObject.GetComponent<IInteractable>();
            //currentInteractable.Interact(); //TEST PLEASE IGNORE
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            canInteract = false;
        }
    }




    // Update is called once per frame
    void Update()
    {

        //SHOOTING
        if(timeToNextShot > 0.0f)
        {
            timeToNextShot -= Time.deltaTime;
            
        }
        else if(Input.GetMouseButton(0) == true)
        {
            Shoot();
        }

        //LASER DEACTIVATION
        if(laserActiveFor > 0.0f)
        {
            laserActiveFor -= Time.deltaTime;
        }
        else
        {
            laser.SetActive(false);
        }

        //INTERACTION BEHAVIOUR
        if (Input.GetAxis("Interact") == 1)
        {
            if(currentInteractable != null && canInteract)
            {
                currentInteractable.Interact(this);
            }
        }

    }

    void Shoot()
    {
        timeToNextShot += shootingInterval;
        laserActiveFor = laserActiveTime;
        laser.SetActive(true);
    }
}
