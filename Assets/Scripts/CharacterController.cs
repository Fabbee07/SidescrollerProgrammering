using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum CharacterState 
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total
}
public class CharacterController: MonoBehaviour
{
    public CharacterState JumpingState = CharacterState.Airborne;


     void Start()
    {
        
    }
   //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed
    
    //Gravity
    public float gravitySpeedPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f;
    public float JumpMaxHeaight = 150.0f;
    public float JumpHeightDelta = 0.0f;
    void Update()
    {
        bool ismoving = false;
        //Gravity

        if(transform.position.y <= GroundLevel) 
        {
            Vector3 characterposition = transform.position;
            characterposition.y = GroundLevel;
            transform.position = characterposition;
            JumpingState = CharacterState.Grounded;
        }
        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            
            
            //Vector3 characterPosition = transform.position;
            //characterPosition.y += MovementSpeedPerSecond * Time.deltaTime;
            //transform.position = characterPosition;
            //ismoving = true;
  
            JumpingState = CharacterState.Jumping;
                JumpHeightDelta = 0.0f;
        }
        if (JumpingState == CharacterState.Jumping) 
        {
            Vector3 characterposition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
            characterposition.y += totalJumpMovementThisFrame;
            transform.position = characterposition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if(JumpHeightDelta >= JumpMaxHeaight) 
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
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
        //Gravity
        if (JumpingState == CharacterState.Airborne)
        {
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= gravitySpeedPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
        }

    }

}
