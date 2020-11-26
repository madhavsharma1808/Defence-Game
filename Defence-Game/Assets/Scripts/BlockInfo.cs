using System.Collections.Generic;
using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    public Block startPoint;
    public Block endPoint;
    public Color startPointColor;
    public Color endPointColor;
    public Color exploringColor;
    public bool destinationReached = false;
    Dictionary<Vector2, Block> gridInfo = new Dictionary<Vector2, Block>();
    Queue<Block> path = new Queue<Block>();
    Vector2[] directions =
        { Vector2.up,
          Vector2.down,
          Vector2.left,
          Vector2.right
        };
    public List<Block> pathTobeFollowed = new List<Block>();
    void Start()
    {
        
    }

    public List<Block> GetPath()
    {
        if (pathTobeFollowed.Count == 0)  //Bcz it will casuse error in the other enemys instnatiated
        {
            ChangingStartAndEndColor();
            AddToDictionary();
            path.Enqueue(startPoint);
            startPoint.isExplored = true;
            BreadthFirstSearch();
            GetPathList();
        }
        return pathTobeFollowed;
    }

    void BreadthFirstSearch()
    {
        while (path.Count > 0 && !destinationReached)
        {
            Block dequeueBlock = path.Dequeue();
            CheckForFinalBlock(dequeueBlock);
            //Debug.Log("Searching From" + dequeueBlock);
            ExploreNeighbours(dequeueBlock);
        }
    }

    void CheckForFinalBlock(Block dequeueBlock)
    {
        if (dequeueBlock == endPoint)
        {
            destinationReached = true;
            endPoint.BlockColor(endPointColor);
        }

    }
    void AddToDictionary()
    {
        var blockArray = FindObjectsOfType<Block>();
        foreach (Block block in blockArray)
        {
            bool isOverlapping = gridInfo.ContainsKey(block.GetBlockPosition() * 10);
            if (isOverlapping)
                Debug.Log("This is Overlapping");
            else
            {
                gridInfo.Add(block.GetBlockPosition(), block);
                // Debug.Log(block.name);
            }

        }
    }

    void ExploreNeighbours(Block neighbour)
    {
        foreach (Vector2 direction in directions)
        {

            Vector2 neighbourCoordinates = (neighbour.GetBlockPosition() + direction);
            try
            {
                Block blockExploring = gridInfo[neighbourCoordinates];
                if (!blockExploring.isExplored)
                {
                    blockExploring.parent = neighbour;
                    //Debug.Log("Exploring" + blockExploring);
                    path.Enqueue(blockExploring);
                    blockExploring.isExplored = true;
                    blockExploring.BlockColor(exploringColor);
                }

            }
            catch
            {
                //error
            }


        }
    }

    void ChangingStartAndEndColor()
    {
        startPoint.BlockColor(startPointColor);
        endPoint.BlockColor(endPointColor);

    }
    void GetPathList()
    {
        Block temp = endPoint;
        while (temp != startPoint)
        {            
            pathTobeFollowed.Add(temp);
            temp.isPlaceable = false;
            temp = temp.parent;
        }
        pathTobeFollowed.Add(startPoint);
        startPoint.isPlaceable = false;
        
        pathTobeFollowed.Reverse();
       
    }

}
