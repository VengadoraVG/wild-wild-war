using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;

    void Update () {
        transform.position = target.transform.position;
    }
}
