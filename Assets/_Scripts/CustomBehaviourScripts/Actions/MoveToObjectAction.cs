using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToObject", story: "[Agent] moves to [Object] at [Velocity] and stops at [StopDistance]", category: "Action", id: "551427ee372c71a4edf67f235eed5858")]
public partial class MoveToObjectAction : Action
{
	[SerializeReference] public BlackboardVariable<GameObject> Agent;
	[SerializeReference] public BlackboardVariable<GameObject> Object;
	[SerializeReference] public BlackboardVariable<float> Velocity;
	[SerializeReference] public BlackboardVariable<float> StopDistance;

	protected override Status OnStart()
	{
		return Status.Running;
	}

	protected override Status OnUpdate()
	{
		if (Vector2.Distance(Agent.Value.transform.position, Object.Value.transform.position) <= StopDistance.Value)
		{
			return Status.Success;
		}
		Vector2 vel = (Object.Value.transform.position - Agent.Value.transform.position).normalized * Velocity * Time.deltaTime;
		Agent.Value.transform.position += new Vector3(vel.x, vel.y, 0);
		return Status.Running;
	}

	protected override void OnEnd()
	{
	}
}

