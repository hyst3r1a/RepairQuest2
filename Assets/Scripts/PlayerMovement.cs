using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController chr;
    Vector3 movement = new Vector3(0, 0, 0);
    Player player;
    public float gravity = 20f;
    // Start is called before the first frame update
    void Start()
    {
        chr = GetComponent<CharacterController>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (chr.isGrounded)
        {
            movement = new Vector3(0, 0, 0);
            movement += transform.forward * Input.GetAxis("Vertical");
            movement += transform.right * Input.GetAxis("Horizontal");
            movement *= player.speed;
            if (Input.GetButton("Jump"))
            {
                movement.y = player.jumpSpeed;
                Debug.Log(movement);

            }
        }
        movement.y -= gravity * Time.deltaTime;
        chr.Move(movement);
        
    }
}
