using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); //GetAxisRaw only returns the values of 0, -1, 1. 
        change.y = Input.GetAxisRaw("Vertical");   //Good for digital movement (vs. GetAxis)
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

}
