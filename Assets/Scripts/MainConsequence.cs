using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public class MainConsequence : MonoBehaviour, IConsequence
    {
        public void Execute(PlayerController controller)
        {
            controller.timer = 60;
        }
    }
}