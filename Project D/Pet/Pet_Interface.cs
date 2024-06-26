using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    Pet[] Evolutions { get; }
    Sprite Sprite { get; }
    string Name { get; }

    int Rate { get; }

    int Attack { get; }
    int Speed { get; }
    int Hp { get; }
}
