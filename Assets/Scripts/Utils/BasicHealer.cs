public class BasicHealer : BasicHealthManipulator
{
    protected override void OnClick() =>
        Heal();

    private void Heal()
    {
        if (Value <= 0)
            return;

        Entity.Increase(Value);
    }
}
