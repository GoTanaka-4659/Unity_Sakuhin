using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBlock : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Destroy(gameObject);
                Debug.Log("LHit");
            }
            Debug.Log("Hit");
        }
    }
}
