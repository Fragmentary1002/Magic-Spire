using QFramework;
using QModel;
using QSystem;
using QUtility;

public class CounterApp : Architecture<CounterApp>
{
    protected override void Init()
    {
        //Model
        this.RegisterModel(new PlayerData());
        this.RegisterModel(new CardPileData());
        this.RegisterModel(new FighterData());
        //System
        this.RegisterSystem(new FightCardManager());
        this.RegisterSystem(new PlayerManager());
        this.RegisterSystem(new EnemyManager());

        //Utility
        this.RegisterUtility(new LogTool());
    }
    // 指定架构
    public IArchitecture GetArchitecture()
    {
        return CounterApp.Interface;
    }
}