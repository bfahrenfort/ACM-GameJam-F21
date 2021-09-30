using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public class PlatformConsequence : IConsequence
    {
        public override void ExecuteConsequence(PlayerController controller)
        {
            foreach (Transform child in GameObject.FindGameObjectWithTag("PlatformRoom").transform)
            {
                if (child.CompareTag("MovingBlock"))
                    child.GetComponent<BlockController>().RandomizeBlock();
            }
        }
    }
}