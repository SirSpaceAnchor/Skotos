using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FC
{
	public class CamControl : MonoBehaviour
	{
	    public Transform playerView;
	    public PlayerControl pc;

	    //CameraPosition
	    public float playerViewYOffset = 0.6f; 
	    public float xMouseSensitivity = 30.0f;
	    public float yMouseSensitivity = 30.0f;

	    //FPS Display
	    public float fpsDisplayRate = 4.0f;

	    private int frameCount = 0;
	    private float dt = 0.0f;
	    private float fps = 0.0f;

	    // CameraRotation
	    private float rotX = 0.0f;
	    private float rotY = 0.0f;

	    private Vector3 moveDirectionNorm = Vector3.zero;
	    private Vector3 playerVelocity = Vector3.zero;
	    private float playerTopVelocity = 0.0f;

	    public GUIStyle style;

	    public void CameraInit()
	    {
        // CursorInvis.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // CamInsideCapCol
        playerView.position = new Vector3(
            transform.position.x,
            transform.position.y + playerViewYOffset,
            transform.position.z);

	    }

	    public void FPSCounter()
	    {
	        frameCount++;
	        dt += Time.deltaTime;
	        if (dt > 1.0 / fpsDisplayRate)
	        {
	            fps = Mathf.Round(frameCount / dt);
	            frameCount = 0;
	            dt -= 1.0f / fpsDisplayRate;
	                 }
	        /* Ensure that the cursor is locked into the screen */
	        if (Cursor.lockState != CursorLockMode.Locked) {
	            if (Input.GetButtonDown("Fire1"))
	                Cursor.lockState = CursorLockMode.Locked;
	        }    	
	    }
	    
	    public void CameraRotation()
	    {
	        rotX -= Input.GetAxisRaw("Mouse Y") * xMouseSensitivity * 0.02f;
	        rotY += Input.GetAxisRaw("Mouse X") * yMouseSensitivity * 0.02f;

	        // X Rot Clamp
	        if(rotX < -90)
	            rotX = -90;
	        else if(rotX > 90)
	            rotX = 90;

	        //ColliderRotation
	        this.transform.rotation = Quaternion.Euler(0, rotY, 0);
	        //Transform
	        playerView.rotation     = Quaternion.Euler(rotX, rotY, 0);
	    }

	    public void CameraMovAdj()
	    {
	    	playerView.position = new Vector3(transform.position.x, transform.position.y + playerViewYOffset, transform.position.z);    	
	    }
	    
	    public void ControlInit()
	    {
			pc.controller = GetComponent<CharacterController>();	    	
	    }

	    private void OnGUI()
	    {
	        GUI.Label(new Rect(0, 0, 400, 100), "FPS: " + fps, style);
	        var ups = pc.controller.velocity;
	        ups.y = 0;
	        GUI.Label(new Rect(0, 15, 400, 100), "Speed: " + Mathf.Round(ups.magnitude * 100) / 100 + "ups", style);
	        GUI.Label(new Rect(0, 30, 400, 100), "Top Speed: " + Mathf.Round(playerTopVelocity * 100) / 100 + "ups", style);
	    }
	}
}