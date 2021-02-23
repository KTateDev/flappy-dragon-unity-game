using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
       GameObject g = Instantiate(gameObject);
    
       float xpos = transform.position.x;
       Vector3 temp = new Vector3(xpos, Random.Range(0, 10f), 0);
       g.transform.position = new Vector3(xpos + 40f, Random.Range(0, 10), 0);
    
    }
}
