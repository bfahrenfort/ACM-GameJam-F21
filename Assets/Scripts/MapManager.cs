using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Custom;

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
            Instantiate(CurrentRoom);
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