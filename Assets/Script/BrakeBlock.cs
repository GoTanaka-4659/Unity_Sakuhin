using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Destroy(gameObject);
                Debug.Log("LHit");
            }
                Debug.Log("Hit");
        }
    }
}
