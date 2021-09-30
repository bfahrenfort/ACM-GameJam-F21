using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public abstract class IConsequence : MonoBehaviour
    {
        public abstract void ExecuteConsequence(PlayerController controller);
    }
}