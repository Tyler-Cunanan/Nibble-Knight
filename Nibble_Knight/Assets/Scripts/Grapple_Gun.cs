using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Gun : MonoBehaviour
{
    private LineRenderer _lineRender;
    private Vector3 _grabPoint;
    public LayerMask _grappable;
    public Transform FirePoint, Cam, player;
    // Start is called before the first frame update
    public float maxDistance = 50f;
    private SpringJoint joint;

    void Start() {
        _lineRender = GetComponent<LineRenderer>();
    }

    void update() {
        DrawRope();
        Debug.Log("Hellow World");
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("click");
            Debug.Log(Input.mousePosition);
            startGrapple();
        }
        else if(Input.GetMouseButtonUp(0)) {
            stopGrapple();
        }
    }

    void DrawRope() {
        _lineRender.SetPosition(0, FirePoint.position);
        _lineRender.SetPosition(1, _grabPoint);
    }

    void startGrapple() {
        RaycastHit hit;
        if (UnityEngine.Physics.Raycast(Cam.position, Cam.forward, out hit, maxDistance)) {
            _grabPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = _grabPoint;

            float distance = Vector3.Distance(player.position, _grabPoint);


            joint.maxDistance = distance * 0.8f;
            joint.minDistance = distance * 0.25f;

            /**
            joint.spring = 1f;
            joint.damper = 1f;
            joint.massScale = 4.5f
            /**/
        }
    }

    void stopGrapple() {

    }

}
