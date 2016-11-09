﻿using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._15_Observer {
	/// <summary>
	/// 热水器
	/// </summary>
	public class Heater {
		private int temperature;
		public string type = "RealFire 001";       // 添加型号作为演示
		public string area = "China Xian";         // 添加产地作为演示

		/// <summary>
		/// 声明委托
		/// </summary>
		/// <param name="sender">主题</param>
		/// <param name="e">数据</param>
		public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);

		//声明事件
		public event BoiledEventHandler Boiled;

		// 可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
		protected virtual void OnBoiled(BoiledEventArgs e) {
			if (Boiled != null) { // 如果有对象注册
				Boiled(this, e);  // 调用所有注册对象的方法
			}
		}

		// 烧水
		public void BoilWater() {
			for (int i = 0; i <= 100; i++) {
				temperature = i;
				if (temperature > 95) {
					//建立BoiledEventArgs 对象。
					BoiledEventArgs e = new BoiledEventArgs(temperature);
					OnBoiled(e);  // 调用 OnBolied方法
				}
			}
		}

		// 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
		public class BoiledEventArgs : EventArgs {
			public readonly int temperature;
			public BoiledEventArgs(int temperature) {
				this.temperature = temperature;
			}
		}
	}

	// 警报器
	public class Alarm {
		public void MakeAlert(Object sender, Heater.BoiledEventArgs e) {
			Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
			//访问 sender 中的公共字段
			Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
			Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
			Console.WriteLine();
		}
	}

	// 显示器
	public class Display {
		public static void ShowMsg(Object sender, Heater.BoiledEventArgs e) {   //静态方法
			Heater heater = (Heater)sender;
			Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
			Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
			Console.WriteLine();
		}
	}

	class ObserverInDotNet : IMain {
		public void AppMain() {
			Heater heater = new Heater();

			heater.Boiled += (new Alarm()).MakeAlert;      //给匿名对象注册方法
			heater.Boiled += Display.ShowMsg;       //注册静态方法

			heater.BoilWater();   //烧水，会自动调用注册过对象的方法
		}
	}

}