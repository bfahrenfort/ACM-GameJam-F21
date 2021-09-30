using System;
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
        public List<GameObject> listRooms;

        public List<String> roomCodes = new List<string>();

        public int NumRooms() { return listRooms.Count;}

        public void destroyRooms()
        {
            roomCodes.Clear();
            roomCodes.Insert(0, "MainRoom");
        }

        private void Awake()
        {
            // Put the main room at the origin
            GameObject mainRoom = Instantiate(listRooms[0], new Vector3(), Quaternion.identity);
            roomCodes.Insert(0, "MainRoom");
            // Give it the specific script it needs
            mainRoom.AddComponent<MainConsequence>();
        }
    }
}