using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Gun : MonoBehaviour
{
    private LineRenderer _lineRender;
    public LayerMask _grappableEnviorment;
    public LayerMask _grappableObject;
    private SpringJoint joint;
    private SpringJoint jointOb;
    
    [Header("Objects")]
    public Transform FirePoint;
    public Transform Cam;
    public Transform player;
    public Rigidbody grappleSource;
    public float minRope = 1f;
    public float maxRope = 30f;
    public float maxDistance = 50f;
    public float pullSpeed = 7f;
    private GameObject currentOb;
    private Vector3 _grabPoint;
    private int swap;
    private float toGrabPoint;

    void Awake() {
        _lineRender = GetComponent<LineRenderer>();
    }

    void Update() {
        //Debug.Log("Hello World");
        //add in range for grapple
        //indicator/assist
        //adjust mass
        if(Input.GetMouseButtonDown(0)) {
            /**/
            Debug.Log("click");
            /**/
            startGrapple();
        }
        else if(Input.GetMouseButtonUp(0)) {
            Debug.Log("unclick");
            stopGrapple();
        }

        if(Input.GetKey("w") && joint) {
            GrapplePull();
        }
        if(Input.GetKey("s") && joint) {
            GrapplePush();
        }
    }

    void LateUpdate() {
        DrawRope();
    }

    void DrawRope() {
        if(!joint) return;

        Debug.Log("Line");

        _lineRender.SetPosition(0, FirePoint.position);
        _lineRender.SetPosition(1, _grabPoint);
    }

    void startGrapple() {
        RaycastHit hit;
        Ray directHit = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("pew");
        //UnityEngine.Physics.Raycast(directHit, out hit, maxDistance, _grappable);
        //Debug.Log(hit.point);

        //add in additional logic if the tag is either layer
        //envior will link player to ob. the other will link the ob to player
        if (UnityEngine.Physics.Raycast(directHit, out hit, maxDistance, _grappableEnviorment)) {
            Debug.Log("catch");
            _grabPoint = hit.point;
            _grabPoint.z = 0f;
            _grabPoint = hit.point;    
            _grabPoint.z = 0f;

            if (hit.collider.gameObject.CompareTag("Moveable")) {
                // grabs an object
                Debug.Log("object");

                swap = 1;
                currentOb = hit.collider.gameObject;
                jointOb = currentOb.AddComponent<SpringJoint>();
                jointOb.autoConfigureConnectedAnchor = false;
                jointOb.connectedAnchor = currentOb.transform.position;
                jointOb.connectedBody = grappleSource;

                toGrabPoint = Vector3.Distance(hit.collider.gameObject.transform.position, player.transform.position);
                jointOb.maxDistance = toGrabPoint*.8f;
                jointOb.minDistance = toGrabPoint*.25f;

                jointOb.spring = 2f;
                jointOb.damper = 7f;
                jointOb.massScale = 4.5f;
            } else {
                //grab anchor
                Debug.Log("Anchor");

                swap = 2;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = _grabPoint;
                joint.connectedBody = grappleSource;

                toGrabPoint = Vector3.Distance(player.transform.position, _grabPoint);
                joint.maxDistance = toGrabPoint*.8f;
                joint.minDistance = toGrabPoint*.25f;

                /**/
                joint.spring = 3f;
                joint.damper = 7f;
                joint.massScale = 4.5f;
                /**/
            }

            _lineRender.positionCount = 2;
        }

        //function to stop the player streatching the rope to far
    }
    /**/
    void stopGrapple() {
        _lineRender.positionCount = 0;
        switch(swap) {
            case 1:
                Destroy(jointOb);
            break;
            case 2:
                Destroy(joint);
            break;
        }
        swap = 0;
        
    }
    /**/
    void GrapplePull() {
        switch(swap) {
            case 1:
                if(jointOb.maxDistance > minRope) {
                    jointOb.maxDistance -= Time.deltaTime*pullSpeed;
                    //jointOb.minDistance -= Time.deltaTime*pullSpeed;
                }
            break;
            case 2:
                if(joint.maxDistance > minRope)
                    joint.maxDistance -= Time.deltaTime*pullSpeed;
                    //joint.minDistance -= Time.deltaTime*pullSpeed;
            break;
        }
        
    }

    void GrapplePush() {
        switch(swap) {
            case 1:
                if(jointOb.maxDistance < maxRope) {
                    jointOb.maxDistance += Time.deltaTime*pullSpeed;
                    //jointOb.minDistance += Time.deltaTime*pullSpeed;
                }
            break;
            case 2:
                if(joint.maxDistance < maxRope) {
                    joint.maxDistance += Time.deltaTime*pullSpeed;
                    //joint.minDistance += Time.deltaTime*pullSpeed;
                }
            break;
        }
    }
}

