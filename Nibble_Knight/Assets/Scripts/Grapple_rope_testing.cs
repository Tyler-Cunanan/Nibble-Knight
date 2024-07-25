using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_rope_testing : MonoBehaviour
{
    public GameObject segment;
    public GameObject Above, Below;

    private GameObject[] Tracking;
    private HingeJoint joint;

    
    
    //private hindgejoint joint;
    
    // Start is called before the first frame update
    void Start()
    {
        //instantiate hindge  
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            for(int i = 0; i < 10; i++) {
                //instance segment
                //attach new segment direction up
                //scan for hit
                    //if hit correct
                        //attach to hit
                    //i = 10    
            }
        }
        if(Input.GetMouseButtonDown(0)) {
            //Destroy();
        }
    }

    void spawnSegment(int len) {
        //adds another link to the chain
    }

    void removed() {
        //removes calls it's connected segment to be destroyed then itself
    }

}
