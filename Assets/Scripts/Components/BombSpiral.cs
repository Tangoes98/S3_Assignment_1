using UnityEngine;
using System.Collections;

public class BombSpiral : MonoBehaviour
{
    public GameObject BombPrefab;
    [Range(5, 25)]
    public float SpiralAngleInDegrees = 10;
    public int BombCount = 10;
    public float StartRadius = 1;
    public float EndRadius = 3;

    /// <summary>
    /// Spawns spirals of BombPrefab game objects around the player. Create BombCount number of bombs 
    /// around the player, with each bomb being spaced SpiralAngleInDegrees apart from the next. The spiral 
    /// starts at StartRadius away from the player and ends at EndRadius away from the player.
    /// </summary>
    /// <returns>An array of the spawned bombs</returns>
    public GameObject[] SpawnBombSpiral()
    {
        StartRadius = 1;

        var playerPosition = GameController.GetPlayerObject().transform.position;

        GameObject[] spiralBombs = new GameObject[BombCount];

        float x;
        float y;

        float angle = 90f;

        var radiusInterval = (EndRadius - StartRadius) / BombCount;


        for (int i = 0; i < BombCount; i++)
        {


            x = Mathf.Sin(Mathf.Deg2Rad * angle) * StartRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * StartRadius;

            StartRadius += radiusInterval;



            spiralBombs[i] = GameObject.Instantiate<GameObject>(BombPrefab);


            spiralBombs[i].transform.position = (new Vector3(x, y, 0) + playerPosition);


            angle -= SpiralAngleInDegrees;

            Destroy(spiralBombs[i], 0.5f);


        }



        return spiralBombs;
    }

}
