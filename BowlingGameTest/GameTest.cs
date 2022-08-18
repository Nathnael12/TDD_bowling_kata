using Xunit;
using BowlingGame;

namespace BowlingGameTest;

public class GameTest
{
    private Game g;
    public GameTest()
    {
        g=new Game();
        
    }
    private void RollMany(int n,int pins){
        for (int i = 0; i < n; i++)
        {
            g.Roll(pins);
        }
    }
    private void RollSpare(){
        g.Roll(5);
        g.Roll(5);
    }
    private void RollStrike(){
        g.Roll(10);
    }
    [Fact]
    public void TestGutterGame()
    {
        RollMany(20,0);
        Assert.Equal(0,g.Score());

    }
    [Fact]
    public void TestAllOnes(){
        RollMany(20,1);
        Assert.Equal(20,g.Score());
    }
    [Fact]
    public void TestOneSpare()
    {
       RollSpare();
       g.Roll(4);
       RollMany(17,0);
       Assert.Equal(18,g.Score());
    }
    [Fact]
    public void TestOneStrike()
    {
        RollStrike();
        g.Roll(4);
        g.Roll(4);
        RollMany(17,0);
        Assert.Equal(26,g.Score());
    }
    [Fact]
    public void TestPerfectGame()
    {
        RollMany(12,10);
        Assert.Equal(300,g.Score());
    }
    
}