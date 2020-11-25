﻿using System.Collections;
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
            Vector3 pos = new Vector3(blockList[i].transform.position.x, transform.position.y, blockList[i].transform.position.z);
            transform.position =pos;
            yield return new WaitForSeconds(1f);
        }
    }
}

