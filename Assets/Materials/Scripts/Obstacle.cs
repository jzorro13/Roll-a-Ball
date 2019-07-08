    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Obstacle : MonoBehaviour {

        public GameObject[] obstacle;
        int current = 0;
        float rotSpeed;
        public float speed;
        float WPradius = 1;

        void Update () {
            if(Vector3.Distance(obstacle[current].transform.position, transform.position) < WPradius)
            {
                current++;
                if (current >= obstacle.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, obstacle[current].transform.position, Time.deltaTime * speed);
    
        }
    }