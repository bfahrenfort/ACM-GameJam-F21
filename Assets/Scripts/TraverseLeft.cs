using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class TraverseLeft: MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            Platformer.Model.PlatformerModel model = Platformer.Core.Simulation.GetModel<Platformer.Model.PlatformerModel>();
            model.player.Teleport(model.spawnPoint.position);
        }
    }
}