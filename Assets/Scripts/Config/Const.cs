namespace Config
{
    //回合状态机
    public enum FightState
    {
        None,
        RoleInit,
        BattleInit,
        Player,
        Enemy,
        Win,
        Loss
    }
    
    //回调点事件
    public enum CallBackPointEventID
    {
        Start,
        BattleBegin, //开始战斗
        BattleEnd,   //战斗结束
        DoDamage,    //攻击
        BeDamaged,  //被攻击
        TurnStart, //回合开始
        TurnEnd,   //回合结束
        DrawCard,    //抽牌
        PlayHand,     //出牌
        End
    }
}