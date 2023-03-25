using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_PickAndPee", menuName = "Behaviour Trees/BT_PickAndPee", order = 1)]
public class BT_PickAndPee : BehaviourTree
{
    public BT_PickAndPee()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        DynamicSelector pickPeeBouquet = new DynamicSelector();

        pickPeeBouquet.AddChild(
            new CONDITION_NeedToPee(),
            new BT_Pee());

        pickPeeBouquet.AddChild(
            new CONDITION_NotEnoughForBouquet(),
            new BT_PickFlowers());

        pickPeeBouquet.AddChild(
            new CONDITION_EnoughForBouquet(),
            new BT_MakeBouquet());

        root = new RepeatForeverDecorator(pickPeeBouquet);

    }
}
