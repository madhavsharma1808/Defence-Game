using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    public Block startPoint;
    public Block endPoint;
    public Color startPointColor;
    public Color endPointColor;
    Dictionary<Vector2, Block> gridInfo = new Dictionary<Vector2, Block>();

    void Start()
    {
        ChangingStartAndEndColor();
        var blockArray = FindObjectsOfType<Block>();
        foreach(Block block in blockArray)
        {
            bool isOverlapping = gridInfo.ContainsKey(block.GetBlockPosition());
            if (isOverlapping)
                Debug.Log("This is Overlapping");
            else
            {
                gridInfo.Add(block.GetBlockPosition(), block);
                Debug.Log(block.name);
            }

        }

    }

    void ChangingStartAndEndColor()
    {
        startPoint.BlockColor(startPointColor);
        endPoint.BlockColor(endPointColor);
        
    }
}
