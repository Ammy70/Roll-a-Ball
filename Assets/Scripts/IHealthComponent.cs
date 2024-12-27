public interface IHealthComponent
{
    public void ApplyDamage(float value);
    public float CheckHealth();
    
    bool IsDead();
}
