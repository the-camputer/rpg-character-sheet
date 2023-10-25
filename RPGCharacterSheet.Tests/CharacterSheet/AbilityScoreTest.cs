using RPGCharacterSheet.Models;

namespace RPGCharacterSheet.Tests.CharacterSheet
{
    public class AbilityScoreTest
    {
        [Fact]
        public void Updating_Score_Updates_Modifier()
        {
            AbilityScore exampleScore = new AbilityScore
            {
                Name = "Test",
                Score = 10
            };
            Assert.Equal(0, exampleScore.Modifier);

            exampleScore.Score = 11;
            Assert.Equal(0, exampleScore.Modifier);

            exampleScore.Score = 12;
            Assert.Equal(1, exampleScore.Modifier);

            exampleScore.Score = 20;
            Assert.Equal(5, exampleScore.Modifier);

            exampleScore.Score = 0;
            Assert.Equal(-5, exampleScore.Modifier);
        }
    }
}
