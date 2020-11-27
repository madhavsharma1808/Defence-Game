using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstantiating : MonoBehaviour
{
    [SerializeField] LookAtEnemy tower;
    [SerializeField] int count = 4;

    
        Queue<LookAtEnemy> towerqueue = new Queue<LookAtEnemy>();


    public void Addnew(Block current)
    {
        if(towerqueue.Count<count)
        {
            print("first");
            LookAtEnemy instantiatedObject = Instantiate(tower, current.transform.position, Quaternion.identity);
            instantiatedObject.standingBlock = current;
            current.isTower = true;
            towerqueue.Enqueue(instantiatedObject);

        }
        else if(towerqueue.Count>=count)
        {
            print("second");
            LookAtEnemy dequedTower=towerqueue.Dequeue();
            dequedTower.standingBlock.isTower = false;
            current.isTower = true;
            dequedTower.standingBlock = current;
            dequedTower.transform.position = current.transform.position;
            towerqueue.Enqueue(dequedTower);
            
           
        }
    }
}
