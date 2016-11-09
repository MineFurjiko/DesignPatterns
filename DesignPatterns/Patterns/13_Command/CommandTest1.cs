using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
