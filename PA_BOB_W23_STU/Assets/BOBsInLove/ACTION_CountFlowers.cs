using UnityEngine;
using BTs;
using FSMs;

public class ACTION_CountFlowers : Action
{

    public string keyIntCounter;

    public ACTION_CountFlowers(string keyIntCounter)  {
        /* Receive action parameters and set them */
        this.keyIntCounter = keyIntCounter;
    }

    private FSM_CountFlowers countFlowers;

    /* Declare private attributes here */

    public override void OnInitialize()
    {
        /* write here the initialization code. Remember that initialization is executed once per ticking cycle */
        countFlowers = ScriptableObject.CreateInstance<FSM_CountFlowers>();
        countFlowers.Construct(gameObject);
        countFlowers.SetParameters(blackboard.Get<int>(keyIntCounter));
        countFlowers.OnEnter();
    }

    public override Status OnTick ()
    {
        countFlowers.Update();
        return Status.RUNNING;
    }

    public override void OnAbort()
    {
        // write here the code to be executed if the action is aborted while running
        countFlowers.OnExit();
    }

}

class FSM_CountFlowers : FiniteStateMachine
{
    private int flowerCounter;
    private GameObject flowerPicked;
    private BOB_Blackboard blackboard;

    public void SetParameters (int flowerCounter)
    {
        this.flowerCounter = flowerCounter;
    }

    public override void OnEnter()
    {
        flowerCounter = GetComponent<BOB_Blackboard>().flowers;
        blackboard = GetComponent<BOB_Blackboard>();
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnConstruction()
    {
        State selectAFlower = new State("Select A Flower",
            () => { },
            () => { flowerPicked = SensingUtils.FindRandomInstanceWithinRadius(gameObject, "FLOWER", 1000); },
            () => { }
        );

        State addFlower = new State("Add Flower",
            () => { flowerCounter = flowerCounter + 1; blackboard.CountFlower(); },
            () => { },
            () => { }
        );

        Transition flowerPick = new Transition("Flower Pick",
           () => { return flowerPicked != null; },
           () => { });

        Transition flowerVanished = new Transition("Flower Vanished",
           () => { return flowerPicked = null; },
           () => { });

        AddStates(selectAFlower, addFlower);
        AddTransition(selectAFlower, flowerPick, addFlower);
        AddTransition(addFlower, flowerVanished, selectAFlower);

        initialState = addFlower;
    }
}