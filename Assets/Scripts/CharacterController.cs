using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController: MonoBehaviour
{
    void Start()
    {
        
    }
   //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed
    
    //Gravity
    public float gravitySpeedPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    void Update()
    {
        //Gravity

        Vector3 gravityPosition = transform.position;
        gravityPosition.y -= gravitySpeedPerSecond * Time.deltaTime;
      if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
        transform.position = gravityPosition;


        //Up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;

        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;

        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;

        }

    }

}
