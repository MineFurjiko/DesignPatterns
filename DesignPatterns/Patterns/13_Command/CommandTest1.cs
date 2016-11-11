using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//命令模式:命令模式是把一个操作或者行为抽象为一个对象中，通过对命令的抽象化来使得发出命令的责任和执行命令的责任分隔开。
//命令模式的实现可以提供命令的撤销和恢复功能。
namespace DesignPatterns.Patterns._13_Command {
	interface ICommand {
		void Execute();
	}

	class LightOnCommand : ICommand {
		private Light light;

		public LightOnCommand(Light l) { this.light = l; }
		public void Execute() {
			light.On();
		}
	}

	class LightOffCommand : ICommand {
		private Light light;

		public LightOffCommand(Light l) { this.light = l; }
		public void Execute() {
			light.Off();
		}
	}

	class Light {
		public void On() {
			Console.WriteLine("Light On.");
		}
		public void Off() {
			Console.WriteLine("Light Off.");
		}
	}

	class ControlPanel {
		private ICommand onCommand, offCommand;

		public ControlPanel() { }
		public ControlPanel(ICommand onCmd, ICommand offCmd) {
			this.onCommand = onCmd;
			this.offCommand = offCmd;
		}

		public void PressOn() {
			onCommand.Execute();
		}
		public void PressOff() {
			offCommand.Execute();
		}
		public void SetCommand(ICommand onCmd, ICommand offCmd) {
			this.onCommand = onCmd;
			this.offCommand = offCmd;
		}
	}

	class CommandTest1 :IMain{
		public void AppMain() {
			Light light = new Light();
			LightOnCommand lightOnCmd = new LightOnCommand(light);
			LightOffCommand lightOffCmd = new LightOffCommand(light);

			ControlPanel cp = new ControlPanel();
			cp.SetCommand(lightOnCmd,lightOffCmd);
			cp.PressOn();
			cp.PressOff();
		}
	}
}
