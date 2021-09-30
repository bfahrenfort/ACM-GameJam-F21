using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;

namespace Custom
{
    public class TraverseLeft: MonoBehaviour
    {
        private bool created = false;
        private MapManager map;

        void Awake()
        {
            map = GameObject.FindWithTag("GameController").GetComponent<MapManager>();
        }
        void OnTriggerEnter2D(Collider2D c)
        {
            if (!created)
            {
                created = true;
                Platformer.Model.PlatformerModel model = Platformer.Core.Simulation.GetModel<Platformer.Model.PlatformerModel>();
                // Instantiate room
                //model.player.Teleport(model.spawnPoint.position);
                if (map.roomCodes.Contains("EnemyRoom"))
                {
                    Platform();
                }
                else if (map.roomCodes.Contains("PlatformRoom"))
                {
                    Enemy();
                }
                else
                {
                    // Randomize room
                    var random = new System.Random();
                    if (random.Next(0, 2) == 1)
                    {
                        Enemy();
                    }
                    else
                    {
                        Platform();
                    }
                }
            }
        }

        void Platform()
        {
            var room = Instantiate(map.listRooms[1], new Vector3(-16, 2, 0), Quaternion.identity);
            room.AddComponent<PlatformConsequence>();
            map.roomCodes.Insert(1, "PlatformRoom");
        }

        void Enemy()
        {
            var room = Instantiate(map.listRooms[2], new Vector3(-16, 1, 0), Quaternion.Euler(0f, 180f, 0f));
            room.AddComponent<EnemyConsequence>();
            map.roomCodes.Insert(1, "EnemyRoom");
        }
    }
}