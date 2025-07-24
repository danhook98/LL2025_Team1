using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToPoint", story: "[Agent] moves to [Point] at [Speed] and stops at [Distance]", category: "Action", id: "ce4ec8f1c3996cfe260757ba02c1ac18")]
public partial class MoveToPointAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Vector2> Point;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<float> Distance;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
		if (Vector2.Distance(Agent.Value.transform.position, Point.Value) <= Distance.Value)
		{
			return Status.Success;
		}
        Vector2 agentVec2 = new Vector2(Agent.Value.transform.position.x, Agent.Value.transform.position.y);
		Vector2 vel = (Point.Value - agentVec2).normalized * Speed * Time.deltaTime;
		Agent.Value.transform.position += new Vector3(vel.x, vel.y, 0);
		return Status.Running;
	}

    protected override void OnEnd()
    {
    }
}

