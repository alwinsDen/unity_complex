using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {   
        //making this public also gives us access to this in the editor.
        // public float charSpeed = 8f;
        
        //but making something public is a bad approach so use serializeField instead to view in editor.
        [SerializeField] private float charSpeed = 8f;
        [SerializeField] private float rotationSpeed = 5f;
        private void Update()
        {
            Vector2 inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W))
            {
                inputVector.y += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                inputVector.y -= 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x += 1;
            }
            
            //when both the W && A are pressed the character will move diagonally with magnitude 1
            //so use normalize
            inputVector = inputVector.normalized;
            
            //to covert in to xyz movement
            Vector3 inputVector3 = new Vector3(inputVector.x,0f,inputVector.y);
            
            //the player moves very fast if the frame rate is high. So we use Time.deltaTime which is the amount of 
            //time between each frame loading.
            transform.position += inputVector3 * Time.deltaTime * charSpeed;
            
            //adding rotations to the duck based on the movement
            // transform.forward = inputVector3; turns the body to the moving direction
            
            //since the character rotates all a sudden, we can slow it down
            //for that we can the Vector3.slerp method. which contains start_val, end_val, intervals
            // https://www.youtube.com/watch?v=AzmVVPWao8U
            transform.forward = Vector3.Slerp(transform.forward,inputVector3,Time.deltaTime * rotationSpeed);
        }
    }
}