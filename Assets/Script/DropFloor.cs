using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFloor : MonoBehaviour
{
    private float rayDistance;

    void Start()
    {
        rayDistance = 1.0f;
    }

    void Update()
    {
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.up);
        Debug.DrawRay(rayPosition, Vector3.up * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.name == "player")
            {
                DropDown();
            }
        }
    }

    void DropDown()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
