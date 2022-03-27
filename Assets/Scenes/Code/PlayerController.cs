using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody characterRigidbody;




    // Start is called before the first frame update
     void Start()
    {
      characterRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = characterRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= speed;
        velocity.y = fallSpeed;
        characterRigidbody.velocity = velocity;


    }
}
