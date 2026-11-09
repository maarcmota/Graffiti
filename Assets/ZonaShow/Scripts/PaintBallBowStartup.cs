using System.Collections;
using MalbersAnimations;
using MalbersAnimations.Weapons;
using PaintIn3D;
using UnityEngine;

/// <summary>Initializes the PaintBall bow and prepares its projectile immediately before firing.</summary>
[DefaultExecutionOrder(1000)]
[DisallowMultipleComponent]
public sealed class PaintBallBowStartup : MonoBehaviour
{
    private MBow configuredBow;

    private void Start()
    {
        var weaponManager = GetComponent<MWeaponManager>();
        if (!TryInitializeBow(weaponManager, out var bow))
        {
            return;
        }

        ConfigureBow(bow);
        StartCoroutine(EnsureBowIsEquipped(weaponManager));
    }

    private bool TryInitializeBow(MWeaponManager weaponManager, out MBow bow)
    {
        bow = null;

        if (weaponManager == null)
        {
            Debug.LogError("PaintBallBowStartup requires an MWeaponManager component.", this);
            return false;
        }

        if (weaponManager.StartWeapon == null ||
            weaponManager.StartWeapon.GetComponent<MBow>() == null)
        {
            Debug.LogError("PaintBallBowStartup requires an MBow StartWeapon.", this);
            return false;
        }

        // The manager schedules its own reset on enable; cancel it before the fallback reset to avoid duplicate bows.
        weaponManager.CancelInvoke(nameof(MWeaponManager.ResetWeaponManager));

        if (weaponManager.Weapon == null)
        {
            weaponManager.ResetWeaponManager();
        }

        bow = weaponManager.Weapon as MBow;
        if (bow == null)
        {
            Debug.LogError("MWeaponManager did not initialize the configured PaintBall bow.", this);
            return false;
        }

        return true;
    }

    private IEnumerator EnsureBowIsEquipped(MWeaponManager weaponManager)
    {
        for (var frame = 0; frame < 10 && weaponManager != null && !weaponManager.WeaponIsActive; frame++)
        {
            yield return null;
        }

        if (weaponManager != null && !weaponManager.WeaponIsActive)
        {
            weaponManager.Equip_Fast();
        }

        if (weaponManager != null && !weaponManager.WeaponIsActive)
        {
            Debug.LogError("MWeaponManager could not equip the PaintBall bow.", this);
        }
    }

    private void ConfigureBow(MBow bow)
    {
        if (configuredBow != null)
        {
            configuredBow.OnBeforeFireProjectile.RemoveListener(PreparePaintProjectile);
        }

        configuredBow = bow;
        configuredBow.OnBeforeFireProjectile.AddListener(PreparePaintProjectile);
    }

    private void OnDestroy()
    {
        if (configuredBow != null)
        {
            configuredBow.OnBeforeFireProjectile.RemoveListener(PreparePaintProjectile);
        }
    }

    // The bow may keep projectile behaviors disabled while it is nocked; restore painting before MProjectile.Fire().
    private void PreparePaintProjectile(GameObject projectileObject)
    {
        if (projectileObject == null)
        {
            Debug.LogError("The PaintBall bow is about to fire a null projectile.", this);
            return;
        }

        var projectile = projectileObject.GetComponent<MProjectile>();
        var decal = projectileObject.GetComponent<CwPaintDecal>();
        var painter = projectileObject.GetComponent<PaintBallProjectilePainter>();
        var hitCollisions = projectileObject.GetComponent<CwHitCollisions>();

        if (projectile == null || decal == null || painter == null || hitCollisions == null)
        {
            Debug.LogError(
                "The PaintBall projectile requires MProjectile, CwPaintDecal, CwHitCollisions, and PaintBallProjectilePainter components.",
                projectileObject);
            return;
        }

        projectile.enabled = true;
        decal.enabled = true;
        hitCollisions.enabled = false;
        painter.enabled = true;
    }
}
