using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public int PowerUpCount = 3;
    public float PowerUpRadius = 1;

    /// <summary>
    /// Spawn a circle of PowerUpCount power up prefabs stored in PowerUpPrefab, evenly spaced, around the player with a radius of PowerUpRadius
    /// </summary>
    /// <returns>An array of the spawned power ups, in counter clockwise order.</returns>

    public GameObject[] SpawnPowerUps()
    {

        var playerPosition = GameController.GetPlayerObject().transform.position;

        GameObject[] powerUps = new GameObject[PowerUpCount];

        float x;
        float y;

        float angle = 60f;

        for (int i = 0; i < PowerUpCount; i++)
        {


            x = Mathf.Sin(Mathf.Deg2Rad * angle) * PowerUpRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * PowerUpRadius;


            powerUps[i] = GameObject.Instantiate<GameObject>(PowerUpPrefab);


            powerUps[i].transform.position = (new Vector3(x, y, 0) + playerPosition);

            angle += (360f / PowerUpCount);

            Destroy(powerUps[i], 0.5f);


        }


        return powerUps;

    }



}