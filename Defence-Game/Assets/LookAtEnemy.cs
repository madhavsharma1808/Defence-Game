using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    [SerializeField] Transform lookingObject;
    [SerializeField] Transform observingObject;

    private void Update()
    {
        lookingObject.LookAt(observingObject);
    }

}
