﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FC
{
	public class PlayerControl : MonoBehaviour
	{
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
			mc.CalcMaxVel();
		}

		public void controller()
		{
			CharacterController controller;
		}
	}
}