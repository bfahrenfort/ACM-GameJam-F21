using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public class MainConsequence : IConsequence
    {
        public override void ExecuteConsequence(PlayerController controller)
        {
            controller.timer = 60;
        }
    }
}