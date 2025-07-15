using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TwoDimensionalLookAt", story: "[Agent] looks at [Object] offsetted by [Offset]", category: "Action", id: "e4ab8c164fd81c230bbf44456c32e103")]
public partial class TwoDimensionalLookAtAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Object;
    [SerializeReference] public BlackboardVariable<float> Offset;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector2 difference = Object.Value.transform.position - Agent.Value.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Agent.Value.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + Offset.Value);
		return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

