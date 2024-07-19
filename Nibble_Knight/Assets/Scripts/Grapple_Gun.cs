using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Gun : MonoBehaviour
{
    private LineRenderer _lineRender;
    public LayerMask _grappable;
    private SpringJoint joint;
    
    [Header("Objects")]
    public Transform FirePoint;
    public Transform Cam;
    public Transform player;
    public float maxDistance = 100f;
    private Vector3 _grabPoint;

    void Awake() {
        _lineRender = GetComponent<LineRenderer>();
    }

    void Update() {
        //Debug.Log("Hello World");
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
        if (UnityEngine.Physics.Raycast(directHit, out hit, maxDistance, _grappable)) {
            Debug.Log("catch");
            _grabPoint = hit.point;
            _grabPoint.z = 0f;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = _grabPoint;

            float toGrabPoint = Vector3.Distance(player.position, _grabPoint);
            joint.maxDistance = toGrabPoint * 0.5f;
            joint.minDistance = toGrabPoint * 0.25f;

            /**
            joint.spring = 10f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
            /**/

            _lineRender.positionCount = 2;
        }
    }
    /**/
    void stopGrapple() {
        _lineRender.positionCount = 0;
        Destroy(joint);
    }
    /**/
}
