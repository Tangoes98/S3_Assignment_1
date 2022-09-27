using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public const float ROTATE_TIME = 0.5f;

    private static Camera sm_sceneCamera;
    private static GameObject sm_playerObject;
    private static GameObject sm_enemyObject;

    private static GameController sm_gameController;

    private void Awake()
    {
        if ( null == sm_gameController )
        {
            sm_gameController = this;
        }
        else
        {
            Destroy( this );
        }
    }

    /// <summary>
    /// Returns the first GameObject with a Player component found in the scene. If one does not exist, an error is logged
    /// </summary>
    /// <returns>The first player found in the scene.</returns>
    public static GameObject GetPlayerObject()
    {
        if ( null == sm_playerObject )
        {
            GetObjectOfType<Player>( out sm_playerObject );
        }
        return sm_playerObject;
    }

    /// <summary>
    /// Returns the first GameObject with an Enemy component found in the scene. If one does not exist, an error is logged
    /// </summary>
    /// <returns>The first enemy found in the scene.</returns>
    public static GameObject GetEnemyObject()
    {
        if ( null == sm_enemyObject )
        {
            GetObjectOfType<Enemy>( out sm_enemyObject );
        }
        return sm_enemyObject;
    }

    public static Camera GetCamera()
    {
        if ( null == sm_sceneCamera )
        {
            GetComponentOfType<Camera>( out sm_sceneCamera );
        }
        return sm_sceneCamera;
    }

    /// <summary>
    /// Returns the first GameObject with an Enemy component found in the scene. If one does not exist, an error is logged
    /// </summary>
    /// <returns>The first enemy found in the scene.</returns>
    private static GameObject GetObjectOfType<T>( out GameObject foundObject ) where T : Component
    {
        foundObject = null;
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach ( GameObject rootObject in rootObjects )
        {
            T searchResult = rootObject.GetComponentInChildren<T>();
            if ( null != searchResult )
            {
                foundObject = searchResult.gameObject;
                break;
            }
        }
        if ( null == foundObject )
        {
            Debug.LogError( string.Format( "There are no objects of type {0} in the scene.", typeof( T ).ToString() ) );
        }
        return foundObject;
    }

    /// <summary>
    /// Returns the first GameObject with an Enemy component found in the scene. If one does not exist, an error is logged
    /// </summary>
    /// <returns>The first enemy found in the scene.</returns>
    private static T GetComponentOfType<T>( out T foundObject ) where T : Component
    {
        foundObject = null;
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach ( GameObject rootObject in rootObjects )
        {
            T searchResult = rootObject.GetComponentInChildren<T>();
            if ( null != searchResult )
            {
                foundObject = searchResult;
                break;
            }
        }
        if ( null == foundObject )
        {
            Debug.LogError( string.Format( "There are no objects of type {0} in the scene.", typeof( T ).ToString() ) );
        }
        return foundObject;
    }

    /// <summary>
    /// Move the first enemy found to a new random position on screen
    /// </summary>
    public static void MoveEnemy()
    {
        if ( null == sm_sceneCamera )
        {
            GameObject cameraObject;
            GetObjectOfType<Camera>( out cameraObject );
            if ( null != cameraObject )
            {
                sm_sceneCamera = cameraObject.GetComponent<Camera>();
            }
        }
        GameObject enemyObject = GetEnemyObject();
        if ( null != enemyObject )
        {
            enemyObject.transform.position = Vector3.up * UnityEngine.Random.Range( -sm_sceneCamera.orthographicSize, sm_sceneCamera.orthographicSize ) + Vector3.right * UnityEngine.Random.Range( -sm_sceneCamera.orthographicSize * sm_sceneCamera.aspect, sm_sceneCamera.orthographicSize * sm_sceneCamera.aspect );
        }
        else
        {
            Debug.Log( "Couldn't find an enemy to move." );
        }
    }

    public static void RotateScreenClockwise90Deg()
    {
        Camera camera = GetCamera();
        float angleRemainder = camera.transform.eulerAngles.z % 90;
        if ( angleRemainder != 0 )
        {
            sm_gameController.StopAllCoroutines();
            camera.transform.rotation = Quaternion.Euler( 0, 0, camera.transform.eulerAngles.z + ( 90 - angleRemainder ) );
        }
        sm_gameController.StartCoroutine( RotateCamera( camera ) );
    }

    private static IEnumerator RotateCamera( Camera camera )
    {
        float startRotation = camera.transform.eulerAngles.z;
        float timer = 0;
        while ( timer < ROTATE_TIME )
        {
            timer = Mathf.Clamp( timer + Time.deltaTime, 0, ROTATE_TIME );
            camera.transform.rotation = Quaternion.Euler( 0, 0, startRotation + 90 * ( -Mathf.Pow( 2, -10 * timer / ROTATE_TIME ) + 1 ) );
            yield return null;
        }
    }

}
