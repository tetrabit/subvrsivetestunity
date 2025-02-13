using UnityEngine;
using UnityEngine.TextCore.Text;

public static class UnitUtilities
{
    public static bool IsOnTarget(BaseCharacter attacker)
    {
        var direction = attacker.Target.transform.position - attacker.transform.position;
        var distance = Vector3.Distance(attacker.transform.position, attacker.Target.transform.position);

        var rangedWeapon = attacker.Weapon as IRangedWeapon;
        var effectiveRange = (rangedWeapon is not null)
            ? rangedWeapon.Range
            : ProjectConstants.MELEE_RANGE;

        var inRange = distance <= effectiveRange;
        var isFacing = Vector3.Angle(attacker.transform.forward, direction) <= 5f;
        
        return inRange && isFacing;
    }
}