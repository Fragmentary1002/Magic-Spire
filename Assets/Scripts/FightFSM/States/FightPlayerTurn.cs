using QFramework;
using UnityEngine;
using Config;
using QSystem;

namespace FightFSM.States
{
    public class FightPlayerTurn : AbstractState<FightState, FightFsm>,ICanGetSystem
    {
        private FightCardManager _fightCardManager;
        public FightPlayerTurn(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
            _fightCardManager = this.GetSystem<FightCardManager>();
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Enemy || mFSM.CurrentStateId == FightState.Win ||
                   mFSM.CurrentStateId == FightState.Loss;
        }

        protected override void OnEnter()
        {
            //  显示敌人的意图或动作
            // EnemyManager.Instance.DisplayIntent();
            Debug.Log("显示敌人的意图或动作");

           
            Debug.Log("抽牌开始");
            //this.SendCommand(new ApplyTimeCommand(ApplyTime.TurnStart));
            
            //FightCardManager.Instance.InitTrun();
            //FightCardManager.Instance.DrawCards(5);
            
            EnumEventSystem.Global.Send(CallBackPointEventID.TurnStart);
        }

        protected override void OnUpdate()
        {

        }

        protected override void OnExit()
        {

            //  EnemyManager.Instance.DisplayReset();


            //回合结束丢弃手牌
            //FightCardManager.Instance.DisCardHandAll();

            //this.SendCommand(new ApplyTimeCommand(ApplyTime.TurnEnd));

            //切换到敌人回合
            //FightFSM.Instance.ChangeType(FightType.Enemy);

            EnumEventSystem.Global.Send(CallBackPointEventID.TurnEnd);
        }
        //指定架构
        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }

    }
}
