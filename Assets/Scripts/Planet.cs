using UnityEngine;

    public class Planet : MonoBehaviour
    {
        public float gravity;
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<BallGravity>().GRAVITY_CONSTANT = gravity;
        }
    }