using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    
    public float gravityScale = 40.0f;
    public static float globalGravity = -9.8f;
    Rigidbody m_rb;

    void OnEnable() 
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;  
    }

    void FixedUpdate() 
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
        
    }
    
    
        }
