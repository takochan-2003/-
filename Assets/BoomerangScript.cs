using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{

    GameObject player;
    PlayerScript playerScript;

    public Rigidbody rb;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        transform.rotation = playerScript.transform.rotation;
        speed = playerScript.throwPower;
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }
}
