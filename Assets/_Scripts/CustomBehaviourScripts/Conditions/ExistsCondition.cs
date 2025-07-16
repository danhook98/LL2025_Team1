using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "exists", story: "[Object] does not exist", category: "Conditions", id: "f41bcbc89c0e1c250063f8f11d559bf5")]
public partial class ExistsCondition : Condition
{
	[SerializeReference] public BlackboardVariable<GameObject> Object;
	public override bool IsTrue()
    {
        if(Object.Value == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
