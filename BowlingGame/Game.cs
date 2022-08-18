namespace BowlingGame;
public class Game
{
    private int score = 0;
    private int frameIndex = 0;
    private List<int> rolls = new List<int>();
    public void Roll(int pins)
    {
        rolls.Add(pins);
    }
    public int Score()
    {
        for (int frame = 0; frame < 10; frame++)
        {
            if (IsSpare(frameIndex))
            {
                score += 10 + SpareBonus(frameIndex);
                frameIndex += 2;
            }
            else if (IsStrike(frameIndex))
            {
                score += 10 + StrikeBonus(frameIndex);
                frameIndex += 1;
            }
            else
            {
                score += SumOfBallsInFrame(frameIndex);
                frameIndex += 2;
            }
        }

        return score;
    }
    public bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }
    public bool IsStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }
    public int SpareBonus(int frameIndex)
    {
        return rolls[frameIndex + 2];
    }
    public int StrikeBonus(int frameIndex)
    {
        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }
    public int SumOfBallsInFrame(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1];
    }
}
