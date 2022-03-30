using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 // About UI
 public SpeechManager manager;

// About Game
 public float speed;
 float hAxis;
 float vAxis;
 bool wDown;
 bool jDown;
 bool isJump;
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
  m_rb = GetComponent<Rigidbody>();
  animator = GetComponentInChildren<Animator>(); 
}
private void Start() 
{
   
}
private void FixedUpdate() 
{
   //Gravity
   Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
  
}

private void Update() 
 {
  GetInput();
  Move();
  Turn();
  Jump();
 }
 void GetInput()
 {
   hAxis = Input.GetAxisRaw("Horizontal");
   vAxis = Input.GetAxisRaw("Vertical");
   wDown = Input.GetButton("Walk");
   jDown = Input.GetButtonDown("Jump");
 }

 void Move()
 {
     moveVec = new Vector3(hAxis, 0, vAxis).normalized;

     transform.position += moveVec * speed *(wDown ? 0.3f : 1f) * Time.deltaTime; 

     animator.SetBool("isRun", moveVec != Vector3.zero);
     animator.SetBool("isWalk", wDown);
 }

 void Turn()
 {
   transform.LookAt(transform.position + moveVec);
 }

 void Jump()
 {
   if(jDown && !isJump)
   {
     m_rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
     animator.SetBool("isJump", true);
     animator.SetTrigger("doJump");

     isJump = true;

   }
 }
  void OnCollisionEnter(Collision collision) 
  {
    if(collision.gameObject.tag == "Floor")
    {
      isJump = false;
    }
    
  }
}

