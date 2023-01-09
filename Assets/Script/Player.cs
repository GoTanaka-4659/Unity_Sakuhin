using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 3;

    void Update()
    {
        if (Hp == 0)
        {
           // Destroy(this.gameObject);
        }
        
    }
}
