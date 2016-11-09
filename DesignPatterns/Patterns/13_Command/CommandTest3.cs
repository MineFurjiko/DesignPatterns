using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._13_Command {
	public class TV {
		public int channel = 0;
		public int preChannel = 0;
		public int volume = 10;
		public void Start() {
			Console.WriteLine("The TV is turned on.");
		}

		public void Stop() {
			Console.WriteLine("The TV is turned off.");
		}

		public void AddVolume(int i) {
			var temp = volume;
			volume += i;
			volume = Math.Max(0, volume);
			volume = Math.Min(50, volume);
			Console.WriteLine("The volume is {0} , following {1} {2} {3}",
				volume, temp,(i>=0?"+":string.Empty),i);

		} 

		public void SetChannel(int i) {
			preChannel = channel;
			channel = i;

			Console.WriteLine("The Channel is {0} ,following {1}  ",
				channel, preChannel);
		}
	}

	public class TVOnCommand : IAdvCommand {
		TV tv;
		public TVOnCommand(TV tv) {
			this.tv = tv;
		}
		public void Execute() {  //注意，你可以在Execute()中添加多个方法
			tv.Start();
		}

		public void UnExecute() {}
	}

	public class TVOffCommand : IAdvCommand {
		TV tv;
		public TVOffCommand(TV tv) {
			this.tv = tv;
		}
		public void Execute() {
			tv.Stop();
		}

		public void UnExecute() { }
	}

	public class TVTuneChannelCommand : IAdvCommand {
		TV tv;
		private int orderChannel = 0;

		public void SetChannel(int i) { this.orderChannel = i; }

		public TVTuneChannelCommand(TV tv,int i) {
			this.tv = tv;
			this.orderChannel = i;
		}

		public void Execute() {
			tv.SetChannel(orderChannel);
		}

		public void UnExecute() {
			tv.SetChannel(tv.preChannel);

		}
	}

	public class TVSetVolumeCommand : IAdvCommand {
		TV tv;
		private int step = 0;

		public void SetStep(int i) { this.step = i; }

		public TVSetVolumeCommand(TV tv, int step) {
			this.tv = tv;
			this.step = step;
		}
		public void Execute() {
			tv.AddVolume(step);
		}

		public void UnExecute() {
			tv.AddVolume(-step);

		}
	}


	// 定义遥控器
	class TVControlPanel {
		private IAdvCommand onCommand;
		private IAdvCommand offCommand;
		private IAdvCommand setChannelCommand;
		private IAdvCommand setVolumeCommand;
		private List<IAdvCommand> cmdList = new List<IAdvCommand>();
		private int current = 0;

		public void PressOn() {
			onCommand.Execute();
		}

		public void PressOff() {
			offCommand.Execute();
		}

		public void SetChannel() {
			setChannelCommand.Execute();
		}

		public void BackChannel() {
			setChannelCommand.UnExecute();
		}

		public void SetVolume(IAdvCommand setVolumeCommand) {
			this.setVolumeCommand = setVolumeCommand;
			this.setVolumeCommand.Execute();

			this.cmdList.Add(this.setVolumeCommand);
			current++;
		}

		public void UndoSetVolume(int levels) {
			Console.WriteLine("---- Undo {0} levels ", levels);
			// Perform undo operations 
			for (int i = 0; i < levels; i++)
				if (current > 0)
					cmdList[--current].UnExecute();
		}

		public void RedoSetVolume(int levels) {
			Console.WriteLine("---- Redo {0} levels ", levels);
			// Perform redo operations 
			for (int i = 0; i < levels; i++)
				if (current < cmdList.Count)
					cmdList[current++].Execute();
		} 

		public void SetPowerCommand(IAdvCommand onCommand, IAdvCommand offCommand) {
			this.onCommand = onCommand;
			this.offCommand = offCommand;
		}

		public void SetTuneChannelCommand(IAdvCommand setChannelCommand) {
			this.setChannelCommand = setChannelCommand;
		}

	}

	class CommandTest3:IMain {
		public void AppMain() {
			TVControlPanel tvcp = new TVControlPanel();
			TV tv = new TV();
			TVOnCommand tvOnCmd = new TVOnCommand(tv);
			TVOffCommand tvOffCmd = new TVOffCommand(tv);

			tvcp.SetPowerCommand(tvOnCmd,tvOffCmd);
			tvcp.PressOn();
			//切换频道
			tvcp.SetTuneChannelCommand(new TVTuneChannelCommand(tv, 35));
			tvcp.SetChannel();
			tvcp.SetTuneChannelCommand(new TVTuneChannelCommand(tv, 27));
			tvcp.SetChannel();
			//回频
			tvcp.BackChannel();
			Console.WriteLine();
			//设置音量
			tvcp.SetVolume(new TVSetVolumeCommand(tv, 4));
			tvcp.SetVolume(new TVSetVolumeCommand(tv, 5));
			tvcp.UndoSetVolume(2);
			tvcp.RedoSetVolume(1);
			//撤销
			Console.WriteLine();
			tvcp.PressOff();
		}
	}
}
