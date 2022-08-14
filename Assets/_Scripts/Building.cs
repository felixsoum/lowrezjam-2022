public class Building : Enemy
{
    protected override void OnDeath()
    {
        if (OwnerSegment)
        {
            OwnerSegment.OnBuildingDeath();
        }
        base.OnDeath();

        ScoreKeeper.AddBuildingScore(Score);
    }
}
