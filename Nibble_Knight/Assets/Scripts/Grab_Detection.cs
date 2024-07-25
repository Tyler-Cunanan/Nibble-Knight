using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Detection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 7) {
            Destroy(this);
            return other.gameObject;
        } else {
            Destroy(this);
            return null;
        }
    }
}
