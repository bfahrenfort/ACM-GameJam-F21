using Platformer.Mechanics;
using UnityEngine;

namespace Custom
{
    public interface IConsequence
    {
        public abstract void Execute(PlayerController controller);
    }
}