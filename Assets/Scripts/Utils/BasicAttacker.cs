public class BasicAttacker : BasicHealthManipulator
{
    protected override void OnClick() =>
        Attack();

    private void Attack()
    {
        if (Value <= 0)
            return;

        Entity.TakeDamage(Value);
    }
}
