using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter(Collider col) {
        door.transform.position += new Vector3 (0, 4, 0); 
    }

    void OnTriggerExit() {
        door.transform.position -= new Vector3 (0, 4, 0); 
    }
}
