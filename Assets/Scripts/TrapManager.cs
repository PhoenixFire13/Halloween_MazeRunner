using UnityEngine;
using System.Collections;

public class TrapManager : MazeCell {

    ParticleSystem trap;

    void Awake()
    {
        trap = GetComponent<ParticleSystem>();
    }
}
