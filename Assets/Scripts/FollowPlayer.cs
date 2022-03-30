using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        // Smoothly move the camera towards that target position
        transform.position = new Vector3(target.position.x + offset.x, + target.position.y + offset.y, offset.z);
    }
}
