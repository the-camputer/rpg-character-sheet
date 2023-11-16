
namespace RPGCharacterSheet.Models
{
    public class Attack
    {
        public string Name { get; set; }
        public int AttackModifier { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }

        public List<string> DamageTypes
        {
            get;
        } = new()
            {
                "Slashing",
                "Piercing",
                "Bludgeoning",
                "Poison",
                "Acid",
                "Fire",
                "Cold",
                "Radiant",
                "Necrotic",
                "Lightning",
                "Thunder",
                "Force",
                "Psychic"
            };
}
}
