using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int clicksToPop = 3; // How many clicks before balloon pop
    public float scaleToInc = 0.1f; // Scale increase each time balloon clicked


    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnMouseDown()
   {
        clicksToPop --; // Reduces clicks by one
        //Inflate balloon
        transform.localScale += Vector3.one * scaleToInc;
        //Check to see if clicks has reached zero
        if(clicksToPop == 0)
        {
            Destroy(gameObject); //Destroys balloon
        }

   }
}
