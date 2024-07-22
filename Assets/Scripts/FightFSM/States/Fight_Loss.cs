using QFramework;
using Config;

namespace FightFSM.States
{
    //战斗失败
    public class FightLoss : AbstractState<FightState, FightFsm>
    {
        public FightLoss(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Player;
        }

        protected override void OnEnter()
        {
            //// 如果战斗没有胜利（win为false），则激活游戏结束的UI组件  
            //if (!win)
            //    gameover.SetActive(true);

        }
    
    }
}