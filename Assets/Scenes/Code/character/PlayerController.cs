using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
// About Game
 public float speed;
 public GameObject[] Tools;
 public bool[] hasTools;

 float hAxis;
 float vAxis;
 
 bool wDown;
 bool jDown;
 bool isJump;
 bool isBorder;
 bool iDown;
 
 Vector3 moveVec;
 Animator animator;

 GameObject nearObject;

 public float gravityScale;
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
    
    //Prevention of passage
   
  
}
private void Update() 
 {
  GetInput();
  Move();
  Turn();
  Jump();
  Interaction();
 }
 void GetInput()
 {
   hAxis = Input.GetAxisRaw("Horizontal");
   vAxis = Input.GetAxisRaw("Vertical");
   wDown = Input.GetButton("Walk");
   jDown = Input.GetButtonDown("Jump");
   iDown = Input.GetButtonDown("Interaction");
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

 void OnTriggerEnterStay(Collider other) 
{
  if((other.gameObject.tag == "Fishing") && Input.GetKeyDown(KeyCode.F))
  {
    animator.SetTrigger("doFishing");
  }
}

   private void OnTriggerStay(Collider other) 
   {
     if(other.tag == "Fishing")
     nearObject = other.gameObject;

     Debug.Log(nearObject.name);
   }

   private void OnTriggerExit(Collider other) 
   {
     nearObject = null;
   }

   void Interaction()
   {
     if(iDown && nearObject != null && !isJump)
     {
       if(nearObject.tag == "Tools")
       {
         
       }

     }
   }
}

