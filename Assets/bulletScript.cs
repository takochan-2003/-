using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    GameObject Player;
    
    
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        //rb.velocity = new Vector3(0, 0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
