using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Transform player;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
    

    }

    void Update()
    {
        if (!player)
        {
            return;
        }
        Vector3 movement = new Vector3(player.position.x - transform.position.x, 0.0f, 0.0f).normalized;
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
       (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
           Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
       );
       GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 180f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
