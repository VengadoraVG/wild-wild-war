using UnityEngine;
using System.Collections;

public class ObstacleAvoider : MonoBehaviour {
    public float originalDistance;
    public GameObject cam;

    [HideInInspector]
    public float desiredDistance;
    private GameObject _rotPivot;

    void Start () {
        originalDistance = desiredDistance = cam.transform.localPosition.z;
        _rotPivot = cam.transform.parent.parent.gameObject;
    }

    void Update () {
        RaycastHit hit;
        Vector3 difference = _rotPivot.transform.position - transform.position;
        if (Physics.Raycast(_rotPivot.transform.position, -difference, out hit,
                            difference.magnitude * 0.8f)) {
            desiredDistance = -(_rotPivot.transform.position - hit.point).magnitude -0.1f;
        } else {
            desiredDistance = originalDistance;
        }

        cam.transform.localPosition = new Vector3(0,0, desiredDistance);
    }
}
