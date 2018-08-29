using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FC
{
	public class PlayerControl : MonoBehaviour
	{
		public CharacterController controller;
		public MovControl mc;
		public CamControl cc;


		void Start ()
		{
			cc.CameraInit();
			cc.ControlInit();
		}
		
		void Update ()
		{
            cc.FPSCounter();
            if (Game.isMenuActive == false)
            {
                if (Game.isPlayerLocked == false)
                {
                    cc.CameraRotation();
                    cc.CameraMovAdj();
                }

                mc.InitMovement();
                mc.InitMovementType();
                mc.CalcMaxVel();
            }
        }
	}
}