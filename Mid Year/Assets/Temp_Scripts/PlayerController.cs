using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour


{
    public float speed = 6.0f;
    public float gravity = -9.8f;

    public float stamina = 1000f;
    public bool recoveringStamina = false;

    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && ((stamina > 0) && !recoveringStamina))
        {
            speed = 9.0f;
            stamina -= 5;
        }

        else if(stamina < 1000)
        {
            stamina += 2.5f;
            speed = 6.0f;

            recoveringStamina = true;

            if(stamina >= 505)
            {
                recoveringStamina = false;
            }
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaY);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
    }
}