using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FC
{
    public class MovControl : MonoBehaviour
    {
        public PlayerControl pc;
        private float forwardMove;
        private float rightMove;

        public float moveSpeed = 7.0f;
        public float runAcceleration = 14.0f;
        public float runDeacceleration = 10.0f;
        public float airAcceleration = 2.0f;
        public float airDecceleration = 2.0f;
        public float airControl = 0.3f;
        public float sideStrafeAcceleration = 50.0f;
        public float sideStrafeSpeed = 1.0f;
        public float jumpSpeed = 8.0f;
        public float moveScale = 1.0f;
        public float friction = 6;
        public float gravity = 20.0f;

        private float playerFriction = 0.0f;
        private Vector3 moveDirectionNorm = Vector3.zero;
        private Vector3 playerVelocity = Vector3.zero;
        private float playerTopVelocity = 0.0f;

        private bool intJump = false;

        public void InitMovementType()
        {
            QueueJump();
            if (pc.controller.isGrounded)
                GroundMove();
            else if (!pc.controller.isGrounded)
                AirMove();
        }

        public void InitMovement()
        {
            pc.controller.Move(playerVelocity * Time.deltaTime);
        }

        public void CalcMaxVel()
        {
            Vector3 udp = playerVelocity;
            udp.y = 0.0f;
            if (playerVelocity.magnitude > playerTopVelocity)
                playerTopVelocity = playerVelocity.magnitude;
        }


        private void SetMovementDir()
        {
            forwardMove = Input.GetAxisRaw("Vertical");
            rightMove = Input.GetAxisRaw("Horizontal");
        }

        private void QueueJump()
        {
            if (Input.GetButtonDown("Jump") && !intJump)
                intJump = true;
            if (Input.GetButtonUp("Jump"))
                intJump = false;
        }

        public void GroundMove()
        {
            Vector3 intdir;

            if (!intJump)
                ApplyFriction(1.0f);
            else
                ApplyFriction(0);

            float scale = MovScale();

            intdir = new Vector3(rightMove, 0, forwardMove);
            intdir = transform.TransformDirection(intdir);
            intdir.Normalize();
            moveDirectionNorm = intdir;

            var intspeed = intdir.magnitude;
            intspeed *= moveSpeed;

            Accelerate(intdir, intspeed, runAcceleration);

            playerVelocity.y = 0;

            if (intJump)
            {
                playerVelocity.y = jumpSpeed;
                intJump = false;
            }
        }

        private void AirMove()
        {
            Vector3 intdir;
            float intvel = airAcceleration;
            float accel;

            float scale = MovScale();

            SetMovementDir();

            intdir = new Vector3(rightMove, 0, forwardMove);
            intdir = transform.TransformDirection(intdir);

            float intspeed = intdir.magnitude;
            intspeed *= moveSpeed;

            intdir.Normalize();
            moveDirectionNorm = intdir;
            intspeed *= scale;

            //AirControlLogic
            float intspeed2 = intspeed;
            if (Vector3.Dot(playerVelocity, intdir) < 0)
                accel = airDecceleration;
            else
                accel = airAcceleration;
            //Strafe
            if (forwardMove == 0 && rightMove != 0)
            {
                if (intspeed > sideStrafeSpeed)
                    intspeed = sideStrafeSpeed;
                accel = sideStrafeAcceleration;
            }

            Accelerate(intdir, intspeed, accel);
            if (airControl > 0)
                AirControl(intdir, intspeed2);

            //Gravity
            playerVelocity.y -= gravity * Time.deltaTime;

        }

        private void AirControl(Vector3 intdir, float intspeed)
        {
            float zspeed;
            float speed;
            float dot;
            float k;

            //Logic:Can||CannotMove
            if (Mathf.Abs(forwardMove) < 0.001 || Mathf.Abs(intspeed) < 0.001)
                return;
            zspeed = playerVelocity.y;
            playerVelocity.y = 0;

            speed = playerVelocity.magnitude;
            playerVelocity.Normalize();

            dot = Vector3.Dot(playerVelocity, intdir);
            k = 32;
            k *= airControl * dot * dot * Time.deltaTime;

            if (dot > 0)
            {
                playerVelocity.x = playerVelocity.x * speed + intdir.x * k;
                playerVelocity.y = playerVelocity.y * speed + intdir.y * k;
                playerVelocity.z = playerVelocity.z * speed + intdir.z * k;

                playerVelocity.Normalize();
                moveDirectionNorm = playerVelocity;
            }

            playerVelocity.x *= speed;
            playerVelocity.y = zspeed;
            playerVelocity.z *= speed;
        }

        private void ApplyFriction(float t)
        {
            Vector3 vec = playerVelocity;
            float speed;
            float newspeed;
            float control;
            float drop;

            vec.y = 0.0f;
            speed = vec.magnitude;
            drop = 0.0f;

            if (pc.controller.isGrounded)
            {
                control = speed < runDeacceleration ? runDeacceleration : speed;
                drop = control * friction * Time.deltaTime * t;
            }

            newspeed = speed - drop;
            playerFriction = newspeed;
            if (newspeed < 0)
                newspeed = 0;
            if (speed > 0)
                newspeed /= speed;

            playerVelocity.x *= newspeed;
            playerVelocity.z *= newspeed;

        }

        private void Accelerate(Vector3 intdir, float intspeed, float accel)
        {
            float addspeed;
            float accelspeed;
            float currentspeed;

            currentspeed = Vector3.Dot(playerVelocity, intdir);
            addspeed = intspeed - currentspeed;
            if (addspeed <= 0)
                return;
            accelspeed = accel * Time.deltaTime * intspeed;
            if (accelspeed > addspeed)
                accelspeed = accelspeed;

            playerVelocity.x += accelspeed * intdir.x;
            playerVelocity.z += accelspeed * intdir.z;
        }

        private float MovScale()
        {
            int max;
            float total;
            float scale;

            max = (int)Mathf.Abs(forwardMove);
            if (Mathf.Abs(rightMove) > max) max = (int)Mathf.Abs(rightMove);
            if (max <= 0)
                return 0;

            total = Mathf.Sqrt(forwardMove * forwardMove + rightMove * rightMove);
            scale = moveSpeed * max / (moveScale * total);

            return scale;
        }
    }
}