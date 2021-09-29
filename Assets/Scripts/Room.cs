using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class Room : MonoBehaviour
    {
        public GameObject Player;
        private PlayerController controller;

        public void setup()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<PlayerController>();
            GameObject.FindGameObjectWithTag("VCam").GetComponent<Cinemachine.CinemachineConfiner>().m_BoundingShape2D = this.GetComponentInChildren<PolygonCollider2D>();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().model.spawnPoint = this.GetComponentInChildren<SpawnPoint>().transform;
        }

        // Update is called once per frame
        void Update()
        {
            if(controller.paused)
            {

            }
        }
    }
}