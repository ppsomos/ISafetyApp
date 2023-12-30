using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public GameObject cameraParent;

    public void OnButtonClick()
    {
        Debug.Log("Came here in Camera Rotate: " + cameraParent.transform.rotation);
        
        Quaternion targetRotation = Quaternion.FromToRotation(cameraParent.transform.rotation.eulerAngles, new Vector3(cameraParent.transform.rotation.eulerAngles.x, (cameraParent.transform.rotation.eulerAngles.y + 90f), cameraParent.transform.rotation.eulerAngles.z));

        //Smooth rotation
        cameraParent.transform.rotation = Quaternion.Lerp(cameraParent.transform.rotation, targetRotation, Time.deltaTime * 1f);

       // cameraParent.transform.rotation = Quaternion.FromToRotation(Vector3.right, cameraParent.transform.rotation);
    }



}
