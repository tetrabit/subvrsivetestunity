public interface IUnit
{
    public float Health { get; set; }
    public IWeapon Weapon { get; set; }
    public float MoveSpeed { get; set; }
    public float RotateSpeed { get; set; }
}
