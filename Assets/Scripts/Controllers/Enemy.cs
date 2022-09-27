using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    
    private void Update()
    {
        if ( Input.GetButtonDown( "CheckVisionCone" ) )
        {
            Debug.Log( GetComponent<VisionCone>().IsPlayerInVisionCone() );
        }

        if ( Input.GetButtonDown( "MoveEnemy" ) )
        {
            GameController.MoveEnemy();
        }
    }

}
