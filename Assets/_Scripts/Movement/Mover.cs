﻿using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField]
        private Transform target;
    
        private NavMeshAgent nm;
        // Start is called before the first frame update
        void Start(){
            nm = GetComponent<NavMeshAgent>();
        }

        void Update()
        {

            //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
            UpdateAnimator();
        }

        public void Cancel(){
            nm.isStopped = true;
        }

        public void MoveTo(Vector3 destination)
        {
            nm.destination = destination;
            nm.isStopped = false;
        }

        private void UpdateAnimator(){
            Vector3 velocity = nm.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }

        public void StartMoveAction(Vector3 destination){
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

    }


}
