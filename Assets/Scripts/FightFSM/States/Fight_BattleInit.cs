using QFramework;
using Config;
namespace FightFSM.States
{
    public class FightBattleInit : AbstractState<FightState, FightFsm>
    {
        public FightBattleInit(FSM<FightState> fsm, FightFsm target) : base(fsm, target)
        {
        }

        protected override bool OnCondition()
        {
            return mFSM.CurrentStateId == FightState.Player;
        }

        protected override void OnEnter()
        {
            // ʵ����һ������ĵ���Ԥ����  ����ʹ�ö���أ�
            // EnemyManager.Instance.CreateEnemy();

            // ������ڽ�����Ļ���ͽ�����Ϊ�ǻ״̬������Ҳ��ע�͵��ˣ�
            //if (endScreen != null)
            //    endScreen.gameObject.SetActive(false);


            // ����ҵ��ƶѼ������ƶѣ���ϴ�ƣ�Ȼ���һ���������Ƽ������еĿ����б���  
            //FightCardManager.Instance.Init();

            //this.SendCommand(new ApplyTimeCommand(ApplyTime.BattleBegin));

            //FightFSM.Instance.ChangeType(FightType.Player);
        }
    }

}