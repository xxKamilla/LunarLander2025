using UnityEngine;

    public class Planet : MonoBehaviour
    {
        public float gravity;
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Gravity>().GRAVITY_CONSTANT = gravity;
        }
    }