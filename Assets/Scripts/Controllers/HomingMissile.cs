using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour
{
    public float ForwardSpeed = 1;
    public float RotateSpeedInDeg = 45;

    // In Update, you should rotate and move the missile to rotate it towards the player.  It should move forward with ForwardSpeed and rotate at RotateSpeedInDeg.
    // Do not use the RotateTowards or LookAt methods.
    void Update()
    {
        Vector3 missilePos = this.transform.position;

        Vector3 enemyPos = GameController.GetEnemyObject().transform.position;

        Vector3 enemy2missile = enemyPos - missilePos;
        
        Vector3 crossPd = Vector3.Cross(enemy2missile, transform.up); // Left to missile is negative, Right to missile is positive


        this.transform.Translate(Vector3.up * ForwardSpeed * Time.deltaTime, Space.Self);

        if (crossPd.z > 0)
        {

            this.transform.Rotate(new Vector3(0f, 0f, -RotateSpeedInDeg) * Time.deltaTime, Space.Self); // Rotating on Z counterclockwise

        }
        else if (crossPd.z < 0)
        {
            this.transform.Rotate(new Vector3(0f, 0f, RotateSpeedInDeg) * Time.deltaTime, Space.Self); // Rotating on Z clockwise

        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime, Space.Self);
        }



        float distEnemy2missile = Mathf.Sqrt(Mathf.Pow(enemy2missile.x, 2f) + Mathf.Pow(enemy2missile.y, 2f));

        if(distEnemy2missile < 1f)
        {
            Destroy(this.gameObject);
        }


    }
}
