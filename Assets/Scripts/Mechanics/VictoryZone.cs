using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            var key = GameObject.FindGameObjectWithTag("GameController").GetComponent<KeyController>();
            if (p != null)
            {
                if (key.AllKeysCollected())
                {
                    var ev = Schedule<PlayerEnteredVictoryZone>();
                    Schedule<ExitGame>(2);
                    ev.victoryZone = this;
                }
            }
        }
    }
}