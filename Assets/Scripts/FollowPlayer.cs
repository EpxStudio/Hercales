using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform playerTransform;

    void FixedUpdate()
    {
        this.transform.position = playerTransform.position - new Vector3(0, 0, 10);
    }
}
