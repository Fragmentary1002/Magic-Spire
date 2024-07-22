using QFramework;
using QModel;
using QSystem;

public class CounterApp : Architecture<CounterApp>
{
    protected override void Init()
    {
        //Model
        this.RegisterModel(new PlayerData());
        this.RegisterModel(new CardPileData());
        //System
        this.RegisterSystem(new FightCardManager());

        //Utility
    }
}