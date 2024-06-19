public class Player : Mob
{
    public bool IsLeft { get; private set; }
    public bool IsRight { get; private set; }

    public Player(int health, int damage, string name, int maxHealth) : base(health, damage, name, maxHealth) { }

    public void SetIsLeft(bool value)
    {
        IsLeft = value;
    }
    public void SetIsRight(bool value)
    {
        IsRight = value;
    }
}
