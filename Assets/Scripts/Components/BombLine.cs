using UnityEngine;
using System.Collections;

public class BombLine : MonoBehaviour
{

    public GameObject BombPrefab;
    public int BombCount;
    public float BombSpacing;


    /// <summary>
    /// Spawn a line of instantiated BombPrefabs behind the player ship. There should be BombCount bombs placed with BombSpacing amount of space between them.
    /// </summary>
    /// <returns>An array containing all the bomb objects</returns>
    public GameObject[] SpawnBombs()
    {

        var bombPosition = GameController.GetPlayerObject().transform.position;

        var bombFacing = GameController.GetPlayerObject().transform.up;

        GameObject[] bombs = new GameObject[BombCount];

        for(int i = 0 ; i < BombCount; i++)
        {
            bombs[i] = GameObject.Instantiate<GameObject>(BombPrefab);

            bombs[i].transform.position = bombPosition + -bombFacing * BombSpacing;

            bombPosition = bombs[i].transform.position + -bombFacing * BombSpacing;

            Destroy(bombs[i], 0.5f);
        }
        


        return bombs;
    }



}
