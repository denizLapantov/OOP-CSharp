namespace Empires.Models.Units
{
    public class Archer : Unit
    {
        private const int ArcherAttackDamage = 7;
        private const int ArcherHealth = 25;

        public Archer()
            : base(ArcherAttackDamage, ArcherHealth)
        {
        }
    }
}
