using Abstractions;

public interface IAttackable : IHealthHolder
{
    void ReceiveDamage(int amount);
    int FactionID { get; }
}