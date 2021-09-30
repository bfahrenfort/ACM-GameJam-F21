using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom;
using Unity.VisualScripting;

namespace Custom
{
    public class MapManager : MonoBehaviour
    {
        [Tooltip("List of rooms and element 0 must be starting room")]
        public Room[] ListRooms;
        private Room CurrentRoom { get; set; }

        public int NumRooms() { return ListRooms.Length;}

        private void Awake()
        {
            CurrentRoom = ListRooms[0];
<<<<<<< HEAD
            Instantiate(CurrentRoom);
            //Platformer.Core.Simulation.Schedule<Platformer.Gameplay.PlayerSpawn>();
=======
            Room mainRoom = Instantiate(CurrentRoom);
            mainRoom.AddComponent<MainConsequence>();
>>>>>>> c10f34c0c60dab39aca51f1cf9bdf98338eee468
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}