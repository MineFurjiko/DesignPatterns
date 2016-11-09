using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._06_Bridge {
	/// <summary>
	/// 抽象遥控器
	/// </summary>
	public abstract class RemoteControl {
		private TV implementor;

		internal TV Implementor {
			get { return implementor; }
			set { implementor = value; }
		}

		public virtual void On() { implementor.On(); }
		public virtual void Off() { implementor.Off(); }
		public virtual void SetChannel() { implementor.TuneChannel(); }
	}

	public class HUAWEI_RemoteControl : RemoteControl {
		public override void SetChannel() {
			Console.WriteLine("HUAWEI RemoteControl Working!");
			base.SetChannel();
		}
	}

	public abstract class TV{
		public abstract void On();
		public abstract void Off();
		public abstract void TuneChannel();
	}

	public class HUAWEI_TV : TV {
		public override void On() {
			Console.WriteLine("华为电视机已经打开了");
		}

		public override void Off() {
			Console.WriteLine("华为电视机已经关闭");
		}

		public override void TuneChannel() {
			Console.WriteLine("华为电视机切换频道");
		}
	}


	class BridgeTest2:IMain {
		public void AppMain() {
			// 创建一个遥控器
			RemoteControl remoteControl = new HUAWEI_RemoteControl();
			remoteControl.Implementor = new HUAWEI_TV();
			remoteControl.On();
			remoteControl.SetChannel();
			remoteControl.Off();
		}
	}
}
