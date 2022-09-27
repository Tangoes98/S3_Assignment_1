using UnityEngine;
using System.Collections;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 1;

    private float moveSpeedX = 0f;
    private float moveSpeedY = 0f;
    /// <summary>
    /// Move the ship using it's transform only based on the current input vector. Do not use rigid bodies.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {
        //Debug.Log("SpeedX: " + moveSpeedX);
        //Debug.Log("SpeedY: " + moveSpeedY);
        
        if (Mathf.Abs(input.x) == 1)
        {
            moveSpeedX += AccelerationTime * Time.deltaTime;

            moveSpeedX = Mathf.Clamp(moveSpeedX, 0f, MaxSpeed);

            this.transform.Translate(input.x * moveSpeedX * Time.deltaTime, 0, 0);
        }else
        {
            moveSpeedX -= DecelerationTime * Time.deltaTime;

            moveSpeedX = Mathf.Clamp(moveSpeedX, 0f, MaxSpeed);
        }

        if (Mathf.Abs(input.y) == 1)
        {
            moveSpeedY += AccelerationTime * Time.deltaTime;

            moveSpeedY = Mathf.Clamp(moveSpeedY, 0f, MaxSpeed);

            this.transform.Translate(0, input.y * moveSpeedY * Time.deltaTime, 0);
        }
        else
        {
            moveSpeedY -= DecelerationTime * Time.deltaTime;

            moveSpeedY = Mathf.Clamp(moveSpeedY, 0f, MaxSpeed);
        }


    }
    
}
