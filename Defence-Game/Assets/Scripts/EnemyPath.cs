using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPath : MonoBehaviour
{

     List<Block> blockList = new List<Block>();
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField]  ParticleSystem goalExplosion;
   

    // Start is called before the first frame update
    void Start()
    {
        BlockInfo blockInfo = FindObjectOfType<BlockInfo>();
        blockList = blockInfo.GetPath();
        StartCoroutine(BlockWayPoints());
    }

    IEnumerator BlockWayPoints()
    {
       
        for (int i = 0; i < blockList.Count; i++)
        {
            Vector3 pos = new Vector3(blockList[i].transform.position.x, transform.position.y, blockList[i].transform.position.z);
            transform.position =pos;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        var vfx = Instantiate(goalExplosion, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}

