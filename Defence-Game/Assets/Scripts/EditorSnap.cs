using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]  //Will select the Parent
public class EditorSnap : MonoBehaviour
{
    TextMesh textMesh;
    Vector3 position;

    void Start()
    {
        
    }
    void Update()
    {
       
        position.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        position.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        position.y = 0;
        transform.position = position;
        textMesh = GetComponentInChildren<TextMesh>();
        string objectText= (position.x / 10) + "," + (position.z / 10);
        if (gameObject.tag == "player")
        {
            textMesh.text = objectText;
            gameObject.name = objectText;
        }
    }

   
}
