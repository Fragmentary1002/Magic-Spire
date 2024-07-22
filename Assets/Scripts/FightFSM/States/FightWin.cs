using QFramework;
using Config;
namespace FightFSM.States
{
    
    public class FightWin : AbstractState<FightState, FightFsm>
    {
        public FightWin(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Player;
        }

        protected override void OnEnter()
        {
            EnumEventSystem.Global.Send(CallBackPointEventID.BattleEnd);
        }
    }

}