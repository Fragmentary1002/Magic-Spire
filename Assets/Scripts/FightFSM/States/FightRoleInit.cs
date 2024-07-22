using QFramework;
using Config;
namespace FightFSM.States
{
     //Õ½¶·Ê§°Ü
    public class FightRoleInit : AbstractState<FightState, FightFsm>
    {
        public FightRoleInit(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.BattleInit;
        }

        protected override void OnEnter()
        {
            EnumEventSystem.Global.Send(CallBackPointEventID.BattleBegin);
        }
    }

}