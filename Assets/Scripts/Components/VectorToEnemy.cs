using UnityEngine;
using System.Collections;

public class VectorToEnemy : MonoBehaviour
{
    private Vector3 enemyToPlayer;


    /// <summary>
    /// Calculated vector from the player to enemy found by GameManager.GetEnemyObject
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The vector from the player to the enemy.</returns>
    public Vector3 GetVectorToEnemy()
    {
        var playerPosition = GameController.GetPlayerObject().transform.position;
        var enemyPosition = GameController.GetEnemyObject().transform.position;
        enemyToPlayer = playerPosition - enemyPosition;

        return enemyToPlayer; 
    }

    /// <summary>
    /// Calculates the distance from the player to the enemy returned by GameManager.GetEnemyObject without using calls to magnitude.
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The scalar distance between the player and the enemy</returns>
    public float GetDistanceToEnemy()
    {
        
        float distance = Mathf.Sqrt(Mathf.Pow(enemyToPlayer.x, 2f)+ Mathf.Pow(enemyToPlayer.y, 2f));


        return distance;
    }
    
}
