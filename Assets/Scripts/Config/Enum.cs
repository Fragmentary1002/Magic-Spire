namespace Config
{
    /// <summary>
    /// 回合状态机
    /// </summary>
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
    
    /// <summary>
    /// 回调点事件
    /// </summary>
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
    
    /// <summary>
    /// 打印信息枚举
    /// </summary>
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
    
    /// <summary>
    /// 角色职业枚举
    /// </summary>
    public enum CharacterClass
    {
        IronChad,
        Silent
    }   
    
    /// <summary>
    /// 卡牌颜色
    /// </summary>
    public enum CardColor
    {
        IronChad,       //战
        Silent,         //猎
        Colorless,      //无色
        Curse,          //诅咒
        Status          //状态
    }

    /// <summary>
    /// 卡牌类型
    /// </summary>
    public enum CardType
    {
        Attack,     //攻击
        Skill,      //技能
        Power       //能力
    }

    /// <summary>
    /// 卡牌作用对象
    /// </summary>
    public enum CardTargetType
    {
        Self,
        Enemy
    };
    
    /// <summary>
    /// 怪物意图大全
    /// </summary>
    public enum EnemyActionType
    {
        // 攻击意图  
        Attack,
        // 阻挡意图  
        Block,
        Buff,
        DoubleHit

    }

    /// <summary>
    /// 怪物类型
    /// </summary>
    public enum MonsterType
    {
        Enemy,      //普通小怪
        EliteEnemy, //精英
        Boss,       //Boss
    }   
    
}