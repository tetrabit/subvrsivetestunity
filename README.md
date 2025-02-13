Unity test for Subvrsive


Question Answer

How would your code change if weapons had special effects, like the ability make targets catch fire?

Currently the damage dealt is just subtracted from the unit that is hit by a projectile by the projectile's damage value. Adding different damage types such as damage over time with fire would require adding a data type, most likely enum to enable the use of flags for more layers of damage types, and that would be passed into a handler on the unit/basecharacter script which would hold a collection of status effects and their time length to subtract the health over time.

How might this system be incorporated into a larger items and inventory system?

As it is the system can already handle a larger library of items, any ranged weapon can be extended from BaseRangedWeapon.cs and its stats changed there. Also ranged weapons can have any ammo made via extending from the BaseProjectile.cs class. For an inventory system a similar solution can be utilized by storing these types or making new base classes for things such as helmets etc.



Technologies used to satisfy requirements

For Unit/Character logic a simple state based logic has been implemented
For efficient memory usage an object pooling system was utilized for the projectiles
For code efficiency with many more players, tested in editor with 100 characters and running at 45 fps on my laptop
