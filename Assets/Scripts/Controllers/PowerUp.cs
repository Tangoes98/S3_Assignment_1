using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private void Update()
    {
        GetComponent<OrbitTarget>().RotateAroundTarget();
    }
}
