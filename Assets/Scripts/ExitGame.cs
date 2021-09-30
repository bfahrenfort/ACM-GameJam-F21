using Platformer.Core;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : Simulation.Event<ExitGame>
{
    public override void Execute()
    {
        Application.Quit();
    }
}
