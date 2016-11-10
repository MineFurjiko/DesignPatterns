using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._17_State {
	class StateAndMediatorTest : IMain {
		public void AppMain() {
			AbstractCardPartner A = new ParterA();
			AbstractCardPartner B = new ParterB();
			// 初始钱
			A.Money = 20;
			B.Money = 20;

			AbstractMediator mediator = new MediatorPater(new InitState());

			// A,B玩家进入平台进行游戏
			mediator.Enter(A);
			mediator.Enter(B);

			// A赢了
			mediator.State = new AWinState(mediator);
			mediator.ChangeCount(5);
			Console.WriteLine("A 现在的钱是：{0}", A.Money);// 应该是25
			Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15

			// B 赢了
			mediator.State = new BWinState(mediator);
			mediator.ChangeCount(10);
			Console.WriteLine("A 现在的钱是：{0}", A.Money);// 应该是25
			Console.WriteLine("B 现在的钱是：{0}", B.Money); // 应该是15
		}
	}

	public abstract class AbstractCardPartner {
		public int Money { get; set; }
		public AbstractCardPartner() {
			Money = 0;
		}

		public abstract void ChangeCount(int count, AbstractMediator mediator);
	}

	public class ParterA : AbstractCardPartner {

		public override void ChangeCount(int count, AbstractMediator mediator) {
			mediator.ChangeCount(count);
		}
	}

	public class ParterB : AbstractCardPartner {
		public override void ChangeCount(int count, AbstractMediator mediator) {
			mediator.ChangeCount(count);
		}
	}

	public abstract class State {
		protected AbstractMediator meditor;
		public abstract void ChangeCount(int count);
	}

	public class AWinState : State {
		public AWinState(AbstractMediator meditor) {
			this.meditor = meditor;
		}

		public override void ChangeCount(int count) {
			foreach (AbstractCardPartner p in meditor.list) {
				ParterA a = p as ParterA;
				// 
				if (a != null) {
					a.Money += count;
				}
				else {
					p.Money -= count;
				}
			}
		}
	}

	public class BWinState : State {
		public BWinState(AbstractMediator concretemediator) {
			this.meditor = concretemediator;
		}

		public override void ChangeCount(int count) {
			foreach (AbstractCardPartner p in meditor.list) {
				ParterB b = p as ParterB;
				// 如果集合对象中时B对象，则对B的钱添加
				if (b != null) {
					b.Money += count;
				}
				else {
					p.Money -= count;
				}
			}
		}
	}

	public class InitState : State {
		public InitState() {
			Console.WriteLine("游戏才刚刚开始,暂时还有玩家胜出");
		}

		public override void ChangeCount(int count) {
			// 
			return;
		}
	}

	public abstract class AbstractMediator {
		public List<AbstractCardPartner> list=new List<AbstractCardPartner>();

		public State State { get; set; }

		public AbstractMediator(State state) {
			this.State = state;
		}

		public void Enter(AbstractCardPartner partner) {
			list.Add(partner);
		}

		public void Exit(AbstractCardPartner partner) {
			list.Remove(partner);
		}

		internal void ChangeCount(int count) {
			State.ChangeCount(count);
		}
	}

	// 具体中介者类
	public class MediatorPater : AbstractMediator {
		public MediatorPater(State initState)
			: base(initState) { }
	}
}
