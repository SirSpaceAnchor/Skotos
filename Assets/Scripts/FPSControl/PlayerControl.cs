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
			cc.CameraRotation();
			cc.CameraMovAdj();

			mc.InitMovement();
			mc.InitMovementType();
			mc.CalcMaxVel();
		}
	}
}