using MalbersAnimations.Weapons;
using PaintIn3D;
using UnityEngine;

/// <summary>Forwards Malbers projectile raycast hits to PaintIn3D's hit cache.</summary>
[DisallowMultipleComponent]
public sealed class PaintBallProjectilePainter : MonoBehaviour
{
    private MProjectile projectile;
    private CwHitCollisions hitCollisions;

    private void Awake()
    {
        projectile = GetComponent<MProjectile>();
        hitCollisions = GetComponent<CwHitCollisions>();

        if (projectile == null || hitCollisions == null)
        {
            Debug.LogError("PaintBallProjectilePainter requires MProjectile and CwHitCollisions components.", this);
            enabled = false;
        }
    }

    private void OnEnable()
    {
        if (projectile == null || hitCollisions == null)
        {
            return;
        }

        // Painting is driven by MProjectile's SphereCast, not by a second physics-collision hit.
        hitCollisions.enabled = false;
        projectile.OnRayCastHit.AddListener(PaintRaycastHit);
    }

    private void OnDisable()
    {
        if (projectile != null)
        {
            projectile.OnRayCastHit.RemoveListener(PaintRaycastHit);
        }
    }

    private void PaintRaycastHit(RaycastHit hit)
    {
        if (hit.collider == null)
        {
            return;
        }

        var root = hitCollisions.Root != null ? hitCollisions.Root : gameObject;
        var position = hit.point + hit.normal * hitCollisions.Offset;
        var rotation = Quaternion.LookRotation(-hit.normal, Vector3.up);

        // Reuse PaintIn3D's cache so the decal receives the same filtering and hit handling as other hit sources.
        hitCollisions.HitCache.InvokePoint(
            root,
            hitCollisions.Preview,
            hitCollisions.Priority,
            1.0f,
            position,
            rotation);
    }
}
