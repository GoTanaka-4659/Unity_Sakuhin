using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private int counter = 0;
    public int Maxcounter = 700;
    public float moveSample = 0.01f;
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float moveZ = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveX, moveY, moveZ));
        counter++;
        
        //X‚É’l‚ª“ü‚Á‚Ä‚¢‚éŽž
        if(moveX!=0)
        {
            if (counter == Maxcounter)
            {
                counter = 0;
                moveX *= -1;
            }
        }
        //Y‚É’l‚ª“ü‚Á‚Ä‚¢‚éŽž
        if(moveY!=0)
        {
            if (counter == Maxcounter)
            {
                counter = 0;
                moveY *= -1;
            }
        }
        //Y‚É’l‚ª“ü‚Á‚Ä‚¢‚éŽž
        if(moveZ!=0)
        {
            if (counter == Maxcounter)
            {
                counter = 0;
                moveZ *= -1;
            }
        }
    }
}
