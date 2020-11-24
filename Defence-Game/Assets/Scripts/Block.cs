using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isExplored = false;
    public Block parent;
    // Start is called before the first frame update
    public Vector2 GetBlockPosition()
    {
        return new Vector2(transform.position.x/10, transform.position.z/10);
    }

    public void BlockColor(Color color)
    {
        MeshRenderer meshRenderer = transform.Find("top").GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
}
