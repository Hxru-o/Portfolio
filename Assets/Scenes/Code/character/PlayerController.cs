using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
// About Game
 public float speed;
 
 //Tools
 public GameObject[] Tools;
 public bool[] hasTools;

 //Status
 public int fish;
 public int coin;
 public int fruit;
 public int SP;

bool Fishingrod;
bool Axe;
bool pickax;
 //Max Status
 public int Maxfish;
 public int Maxcoin;
 public int Maxfruit;
 public int MaxSP;

 float hAxis;
 float vAxis;
 
 bool wDown;
 bool jDown;
 bool isJump;
 bool isBorder;
 bool iDown;
 bool sDown1;
 bool sDown2;
 bool sDown3;
 bool sDown4;
 bool sDown5;
 bool isFishing;
 bool isRun;
 bool isTree;

 bool isMining;
 bool doMining;

[SerializeField]
private Text interactionText;
[SerializeField]
private GameObject rock_prefab;
[SerializeField]
private GameObject fish_prefab;
 
 Vector3 moveVec;
 Animator animator;

 GameObject nearObject;
 GameObject equipTool;

[SerializeField]
 private int DropItemcount;

 [SerializeField]
 private Inventory theInventory;
[SerializeField]
private GameObject apple_prefab;
 int equpToolIndex = -1;

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
}
private void Update() 
 {
  GetInput();
  Move();
  Turn();
  Jump();
  Interaction();
  Swap();
 }
 void GetInput()
 {
   hAxis = Input.GetAxisRaw("Horizontal");
   vAxis = Input.GetAxisRaw("Vertical");
   wDown = Input.GetButton("Walk");
   jDown = Input.GetButtonDown("Jump");
   iDown = Input.GetButtonDown("Interaction");
   sDown1 = Input.GetButtonDown("Swap1");
   sDown2 = Input.GetButtonDown("Swap2");
   sDown3 = Input.GetButtonDown("Swap3");
   sDown4 = Input.GetButtonDown("Swap4");
   sDown5 = Input.GetButtonDown("Swap5");
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

    
  
  void OnTriggerEnter(Collider other) 
  {
    if(other.tag == "Tools")
    {
      Item item = other.GetComponent<Item>();
    }
  }
  void OnTriggerStay(Collider other)
   {
     if (other.tag == "Tools")
     nearObject = other.gameObject;
     if (other.tag == "Fishing")
     nearObject = other.gameObject;
     if (other.tag == "Shop")
     nearObject = other.gameObject;
     if (other.tag == "Rock")
     nearObject = other.gameObject;
     if (other.tag == "DropItem")
     nearObject = other.gameObject;
     if (other.tag == "Tree")
     nearObject = other.gameObject;
   }
   public void OnTriggerExit(Collider other) 
   {
    if (other.tag == "Tools")
     nearObject = null;
    if (other.tag == "Fishing")
     nearObject = null;
    if (other.tag == "Shop")
      nearObject = null;
    if (other.tag == "Rock")
    nearObject = null;
    if (other.tag == "DropItem")
    nearObject = null;
    if (other.tag == "Tree")
    nearObject = null;

   }

   void Swap()
   {
     if(sDown1 && (!hasTools[0] || equpToolIndex == 0))
     return;
     if(sDown2 && (!hasTools[1] || equpToolIndex == 1))
     return;
     if(sDown3 && (!hasTools[2] || equpToolIndex == 2))
     return;
     if(sDown4 && (!hasTools[3] || equpToolIndex == 3))
     return;
     if(sDown5 && (!hasTools[4] || equpToolIndex == 4))
     return;

     int ToolIndex = -1;
     if(sDown1) ToolIndex = 0;
     if(sDown2) ToolIndex = 1;
     if(sDown3) ToolIndex = 2;
     if(sDown4) ToolIndex = 3;
     if(sDown5) ToolIndex = 4;
     
     if((sDown1 || sDown2 || sDown3 || sDown4 || sDown5) && !isJump)
     {
       if(equipTool != null)
          equipTool.SetActive(false);

      equpToolIndex = ToolIndex;
       equipTool = Tools[ToolIndex];
       equipTool.SetActive(true);
     }
   }
   void Interaction()
   {
     if(iDown && nearObject != null && !isJump)
     {
       if(nearObject.tag == "Tools")
       {
         Item item = nearObject.GetComponent<Item>();
         int ToolIndex = item.value;
         hasTools[ToolIndex] = true;

         Destroy(nearObject);
       }
       else if(nearObject.tag == "Shop")
       {
         Store store = nearObject.GetComponent<Store>();
         store.Enter(this);
       }
       if(nearObject.tag == "Fishing")
       {
          if(iDown && equpToolIndex == 0)
          { 
            animator.SetTrigger("doFishing");
            animator.SetBool("isFishing", true);
            Invoke("Fish",6f);
            Destroy(nearObject);
          }
          
        }
        if(nearObject.tag == "Rock")
        {
          if(iDown && equpToolIndex == 2)
          {
          animator.SetTrigger("doMining");
          animator.SetBool("isMining", true);
          isMining = false;
          Invoke("Rock",1.5f);
          Destroy(nearObject);
          }
        }
        if(nearObject.tag == "DropItem")
        {
          Debug.Log ("획득하였습니다");
          theInventory.Acquireitem(nearObject.GetComponent<ItemPickup>().item);
          Destroy(nearObject);
        }
        if(nearObject.tag == "Tree")
        {
          if(iDown && equpToolIndex == 1)
          {
            animator.SetTrigger("doTree");
            animator.SetBool("isTree",true);
            isTree = false;
            Invoke("Tree",1.5f);
            Destroy(nearObject);
          }
        } 
      }
    }
         void Fish()
        {
          for(int i = 0; i <= DropItemcount; i++)
            {Instantiate (fish_prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);}
        }
        void Rock()
        {
          for(int i = 0; i <= DropItemcount; i++)
        {Instantiate (rock_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);}
        }
        void Tree()
        {
          for(int i = 0; i <= DropItemcount; i++)
          {Instantiate (apple_prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);}
        }        
}





