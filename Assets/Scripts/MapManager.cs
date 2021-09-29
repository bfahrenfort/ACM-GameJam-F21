using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom;

namespace Custom
{
    public class MapManager : MonoBehaviour
    {
        [Tooltip("List of rooms and element 0 must be starting room")]
        public Room[] Rooms;
        Room CurrentRoom;

        public int NumRooms() { return Rooms.Length;}

        // Start is called before the first frame update
        void Start()
        {
            CurrentRoom = Rooms[0];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}