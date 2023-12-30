using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator doorA1;
    public Animator doorB1;
    public Animator doorA2;
    public Animator doorB2;
    public Animator doorA3;
    public Animator doorB3;
    public Animator doorA4;
    public Animator doorB4;
    public Animator doorA5;
    public Animator doorB5;
    public Animator doorA6;
    public Animator doorB6;
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "Door1")
        {
            doorA1.SetBool("IsOpen2", true);
            doorB1.SetBool("IsOpen", true);
        }
        if (this.gameObject.tag == "Door2")
        {
            doorA2.SetBool("IsOpen", true);
            doorB2.SetBool("IsOpen2", true);
        }
        if (this.gameObject.tag == "Door3")
        {
            doorA3.SetBool("IsOpen2", true);
            doorB3.SetBool("IsOpen", true);
        }
        if (this.gameObject.tag == "Door4")
        {
            doorA4.SetBool("IsOpen2", true);
            doorB4.SetBool("IsOpen", true);
        }
        if (this.gameObject.tag == "Door5")
        {
            doorA5.SetBool("IsOpen", true);
            doorB5.SetBool("IsOpen2", true);
        }
        if (this.gameObject.tag == "Door6")
        {
            doorA6.SetBool("IsOpen", true);
            doorB6.SetBool("IsOpen2", true);
        }
         
        
            
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "Door1")
        {
            doorA1.SetBool("IsOpen2", false);
            doorB1.SetBool("IsOpen", false);
        }
        if (this.gameObject.tag == "Door2")
        {
            doorA2.SetBool("IsOpen", false);
            doorB2.SetBool("IsOpen2", false);
        }
        if (this.gameObject.tag == "Door3")
        {
            doorA3.SetBool("IsOpen2", false);
            doorB3.SetBool("IsOpen", false);
        }
        if (this.gameObject.tag == "Door4")
        {
            doorA4.SetBool("IsOpen2", false);
            doorB4.SetBool("IsOpen", false);
        }
        if (this.gameObject.tag == "Door5")
        {
            doorA5.SetBool("IsOpen", false);
            doorB5.SetBool("IsOpen2", false);
        }
        if (this.gameObject.tag == "Door6")
        {
            doorA6.SetBool("IsOpen", false);
            doorB6.SetBool("IsOpen2", false);
        }
    }
}
