using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform _transform;
   [SerializeField]

    // Update is called once per frame
    void Update()
    {
     _transform.Rotate(0.0f,0.3f,0f);
    }
    void Awake(){
        
    }
    
}
