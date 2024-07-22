using QFramework;
using Config;
namespace FightFSM.States
{   
    
    //敌人回合
    public class FightEnemyTurn : AbstractState<FightState, FightFsm>
    {

        public FightEnemyTurn(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Player || mFSM.CurrentStateId==FightState.Win ||  mFSM.CurrentStateId==FightState.Loss ;
        }
        protected override void OnEnter()
        {

            //// 开始一个新的协程来处理敌人的回合。
            //StartCoroutine(HandleEnemyTurn());

        }

        protected override void OnExit() {
            //重置玩家防御
            //PlayerActionManager.Instance.ResetCurrentBlock();

            //FightFSM.Instance.ChangeType(FightType.Player);

        }
    }
   
}