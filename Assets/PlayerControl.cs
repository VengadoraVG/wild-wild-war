using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public GameObject viewport;
    public float jumpVelocity;

    private Rigidbody _body;
    private NavMeshAgent _agent;
    private bool _isJumping = false;

    void Awake () {
        _agent = GetComponent<NavMeshAgent>();
        _body = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
    }

    void Update () {
        Vector3 deltaMovement =
            (viewport.transform.right * Input.GetAxis("Horizontal") +
             viewport.transform.forward * Input.GetAxis("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space)) {
            _isJumping = true;
            _agent.enabled = false;
            _body.isKinematic = false;
            _body.useGravity = true;
            _body.velocity += jumpVelocity * Vector3.up;
        }

        if (!_isJumping) {
            _agent.SetDestination(transform.position + deltaMovement * 0.5f);
        }
    }
}
