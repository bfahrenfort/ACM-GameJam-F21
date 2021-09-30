using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public class EnemyConsequence : IConsequence
    {
        private bool triggered = false;
        private float timer = 5; // 5s cooldown
        public override void ExecuteConsequence(PlayerController player)
        {
            if (triggered) // Trigger warning
            {
                triggered = false;
                foreach (Transform child in GameObject.FindGameObjectWithTag("EnemyRoom").transform)
                {
                    if (child.CompareTag("Enemy"))
                        child.GetComponent<EnemyController>().speed *= 2;
                }
            }
        }

        public void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 5;
                triggered = true;
            }
        }
    }
}