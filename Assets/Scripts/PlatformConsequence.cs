using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public class PlatformConsequence : MonoBehaviour, IConsequence
    {
        public void Execute(PlayerController player)
        {
            foreach (Transform child in GameObject.FindWithTag("PlatformRoom").transform)
            {
                //child.GetComponent<BlockController>().RandomizeBlock();
            }
        }
    }
}