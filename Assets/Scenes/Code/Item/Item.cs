using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public enum Type {Tools, Fruit, Fish,coin};
   public Type type;
   public int value;
   public static float globalGravity = -9.8f;
   public float gravityScale;
   Rigidbody m_rb;
private void Awake() 
{
  m_rb = GetComponent<Rigidbody>();
  
}
  private void FixedUpdate() 
{
   //Gravity
   Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
  
}
void Update() 
   {
      
   }
}
