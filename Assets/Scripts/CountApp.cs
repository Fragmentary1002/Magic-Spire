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
        this.RegisterModel(new ConfigDicData());
        //System
        this.RegisterSystem(new FightCardManager());
        this.RegisterSystem(new PlayerManager());
        this.RegisterSystem(new EnemyManager());
        this.RegisterSystem(new UIPoolManager());

        //Utility
        this.RegisterUtility(new LogTool());
        this.RegisterUtility(new FanCardLayout());
    }
    // 指定架构
    public IArchitecture GetArchitecture()
    {
        return CounterApp.Interface;
    }
}