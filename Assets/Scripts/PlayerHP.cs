using UnityEngine;


namespace AG3961
{
    public class PlayerHP : MonoBehaviour, IDamageable
    {
        private int maxHP = 100;
        [SerializeField] private int currentHP;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentHP = maxHP;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(10);
            }
        }

        public void TakeDamage(int amount)
        {
            Debug.Log("Took Damage " + amount);
            currentHP -= amount;
        }
    }
}

