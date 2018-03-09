using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject slopePivot;
    public GameObject rotationPivot;
    public Vector2 angularVelocity;
    public float lookDownLimit = 130;
    public float lookUpLimit = 300;

    [HideInInspector]
    public Vector2 deltaRot;
    [HideInInspector]
    public float slope;

    void Update () {
        deltaRot =
            Vector2.Scale(new Vector2(-Input.GetAxis("Mouse Y"),
                                      Input.GetAxis("Mouse X")),
                          angularVelocity) * Time.deltaTime;
        float dot =
            Vector3.Dot(slopePivot.transform.up,
                        rotationPivot.transform.forward);
        float angle =
            Vector3.Angle(slopePivot.transform.forward,
                          rotationPivot.transform.forward);

        slope = dot < 0? 360-angle: angle;

        if ((!LookingTooLow() && !LookingTooHigh()) ||
            (LookingTooLow() && deltaRot.x < 0) ||
            (LookingTooHigh() && deltaRot.x > 0)) {
            slopePivot.transform.Rotate(deltaRot.x, 0, 0);
        }
        rotationPivot.transform.Rotate(0, deltaRot.y, 0);
    }

    public bool LookingTooLow () {
        return lookDownLimit <= slope && slope <= 180;
    }

    public bool LookingTooHigh () {
        return 180 <= slope && slope <= lookUpLimit;
    }
}
