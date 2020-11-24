using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

     List<Block> blockList = new List<Block>();
    // Start is called before the first frame update
    void Start()
    {
        BlockInfo blockInfo = FindObjectOfType<BlockInfo>();
        blockList = blockInfo.pathTobeFollowed;
        StartCoroutine(BlockWayPoints());
    }

    IEnumerator BlockWayPoints()
    {

        for (int i = 0; i < blockList.Count; i++)
        { 
            transform.position = blockList[i].transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}

