using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using CannonGame;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ShootProjectile", story: "Shoots [Projectile] at [Point] At [Rate] With [Module]", category: "Action", id: "15a56927adeec34dd3ef8a8ba559aa88")]
public partial class ShootProjectileAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Projectile;
    [SerializeReference] public BlackboardVariable<Transform> Point;
    [SerializeReference] public BlackboardVariable<float> Rate;
    [SerializeReference] public BlackboardVariable<ShooterModule> Module;
    float nextTimeToShoot;
    protected override Status OnStart()
    {
		nextTimeToShoot = Time.time + 1 / Rate.Value;
		return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Time.time > nextTimeToShoot)
        {
            Module.Value.Shoot(Projectile.Value, Point.Value);
            nextTimeToShoot = Time.time + 1 / Rate.Value;
			return Status.Success;

        }
        else
        {
			return Status.Running;
		}
    }

    protected override void OnEnd()
    {
    }
}

