using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour
{

    public float AngleSweepInDegrees = 60;
    public float ViewDistance = 3;

    /// <summary>
    /// Calculates whether the player is inside the vision cone of an enemy as defined by the AngleSweepIndegrees
    /// and ViewDistance varilables. Do not use any magnitude or Distance methods.  You may use any of the previous
    /// methods you have written.
    /// </summary>
    /// <see cref="GameController"/>
    /// <returns>Whether the player is within the enemy's vision cone.</returns>
    public bool IsPlayerInVisionCone()
    {
        GameController.GetPlayerObject().GetComponent<VectorToEnemy>().GetVectorToEnemy();

        GameController.GetPlayerObject().GetComponent<VectorToEnemy>().GetDistanceToEnemy();

        Vector3 distanceV = GameController.GetPlayerObject().GetComponent<VectorToEnemy>().GetVectorToEnemy();

        var theta = Mathf.Atan2(distanceV.y, distanceV.x) * Mathf.Rad2Deg;

        var minDeg = AngleSweepInDegrees;
        var maxDeg = AngleSweepInDegrees * 2;

        var distance = GameController.GetPlayerObject().GetComponent<VectorToEnemy>().GetDistanceToEnemy();

        if(distance < ViewDistance && theta > minDeg && theta < maxDeg)
        {

            Debug.Log("player is inside the cone area.");

            return true;
        }
        else
        {
            return false;
        }






    }
    
}
