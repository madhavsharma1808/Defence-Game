using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 GetBlockPosition()
    {
        return new Vector2(transform.position.x, transform.position.z);
    }

    public void BlockColor(Color color)
    {
        MeshRenderer meshRenderer = transform.Find("top").GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
}
