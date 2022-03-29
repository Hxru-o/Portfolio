using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public float speed;
 float hAxis;
 float vAxis;

 bool wDown;

 Vector3 moveVec;

 Animator animator;
 
 public float gravityScale = 40.0f;
    public static float globalGravity = -9.8f;
    Rigidbody m_rb;
private void OnEnable() 
{
    m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;  
  
}
private void Awake() 
{
  animator = GetComponentInChildren<Animator>(); 
}
private void Start() 
{
   
}
private void FixedUpdate() 
{
   Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
  
}

private void Update() 
 {
  hAxis = Input.GetAxisRaw("Horizontal");
  vAxis = Input.GetAxisRaw("Vertical");
  wDown = Input.GetButton("Walk");

  moveVec = new Vector3(hAxis, 0, vAxis).normalized;

  transform.position += moveVec * speed *(wDown ? 0.3f : 1f) * Time.deltaTime; 

  animator.SetBool("isRun", moveVec != Vector3.zero);
  animator.SetBool("isWalk", wDown);

  transform.LookAt(transform.position + moveVec);
 }
}

