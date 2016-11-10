using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._17_State {
	/// <summary>
	/// 电灯类
	/// </summary>
	public class Light {
		private LightState state;

		public LightState State {
			get { return state; }
			set { state = value; }
		}
		public Light(LightState state) {
			this.state = state;
		}

		public void PressSwich() {
			state.PressSwich(this);
		}
	}

	/// <summary>
	/// 抽象的电灯状态类，相当于State类
	/// </summary>
	public abstract class LightState {
		public abstract void PressSwich(Light light);
	}

	public class On : LightState {

		public override void PressSwich(Light light) {
			Console.WriteLine("Turn off the light.");
			light.State = new Off();
		}
	}

	public class Off : LightState {

		public override void PressSwich(Light light) {
			Console.WriteLine("Turn on the light.");
			light.State = new On();
		}
	}


	class StateSimpleTest:IMain {
		public void AppMain() {
			// 初始化电灯，原始状态为关
			Light light = new Light(new Off());

			// 第一次按下开关，打开电灯
			light.PressSwich();
			// 第二次按下开关，关闭电灯
			light.PressSwich();

		}
	}
}
