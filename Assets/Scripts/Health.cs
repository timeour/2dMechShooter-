using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
        //Хп врага
        public int health;
        public int healthMax;

        // Use this for initialization
        void Start () {
                //Хп становится максимальным при старте
                health = healthMax;
        }
        
        // Update is called once per frame
        void Update () {
        
        }
}