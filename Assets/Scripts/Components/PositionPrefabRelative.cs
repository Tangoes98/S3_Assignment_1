using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefabRelative : MonoBehaviour
{
    public GameObject Prefab;
    public Vector3 SpawnOffset;

    /// <summary>
    /// Instantiates the game object stored in the variable Prefab at SpawnOffset distance away from the player. The object is a 
    /// root object.
    /// </summary>
    /// <returns>the newly spawned object int he right position.</returns>
    public GameObject PositionPrefabAtRelativePosition()
    {
        //instantiate object
        //get the player position
        //set the position of the object offset from the player position
        //pseudocode

        var prefab = GameObject.Instantiate<GameObject>(Prefab);
       
        //var playerRef = GameController.GetPlayerObject();
        var playerPosition = GameController.GetPlayerObject().transform.position;

        var prefabPosition = playerPosition + SpawnOffset;

        prefab.transform.position = prefabPosition;


        return prefab;
    }

}
