using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple_Gun : MonoBehaviour
{
    private LineRenderer _lineRender;
    private Vector3 _grabPoint;
    public LayerMask _grappable;
    public Transform FirePoint, gun;
    // Start is called before the first frame update
    public float maxDistance = 50f;
    private SpringJoint joint;

    void Awake() {
        _lineRender = GetComponent<LineRenderer>();
    }

    void update() {
        if(Input.GetMouseButtonDown()) {
            startGrapple();
        }
        else if(Input.GetMouseButtonUp()) {
            stopGrapple();
        }
    }


    void startGrapple() {
        RaycastHit hit;
        if(Physics.Raycast(gun.position, gun.forward, out hit, maxDistance)) {
            _grabPoint = hit;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = _grabPoint;

            float distance = Vector3.Distance(Transform.position, _grabPoint);

            // distances the grapple is allowed to be at
            joint.maxDistance = distance*0.8f;
            joint.minDistance = distance*0.25f;
            
            // to fit feel
            joint.spring = 1.0f;
            joint.damper = 1.0f;
            joint.massScale = 4.5f;

        }
    }

    void stopGrapple() {

    }

}
