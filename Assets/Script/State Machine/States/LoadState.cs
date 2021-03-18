using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State {

    public float porcentagem;
    public override void Enter() {
        base.Enter();
        print("Agora vai");
    }
}
