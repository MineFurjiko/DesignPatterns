using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._02_Singleton {
	//单例模式
	class GameManager {
		private static GameManager instance;
		private static int initTime = 0;

		public static GameManager Instance {
			get {
				if (instance == null) {
					instance = new GameManager();
					initTime++;
				}
				return instance;
			}
		}

		public static void PrintInitTime() {
			Console.WriteLine("initTime: "+initTime.ToString());
		}

		public void doSomethings() {
			Console.WriteLine("GM do somethings!");
		}

		//私有构造函数保证外部无法创建实例
		private GameManager() { }

	}

	 class TimeManager {
		public static TimeManager Instance;
		private static int initTime = 0;

		static TimeManager() {
			if (Instance==null) {
				Instance = new TimeManager();
				initTime++;
			}
		}

		public void doSomethings() {
			Console.WriteLine("TM do somethings!");
		}

		public static void PrintInitTime() {
			Console.WriteLine("initTime: " + initTime.ToString());
		}

	}

	class SingletonTest:IMain {

		public void AppMain() {
			GameManager.PrintInitTime();
			var instance = GameManager.Instance;
			GameManager.PrintInitTime();
			GameManager.Instance.doSomethings();
			var instance2 = GameManager.Instance;
			GameManager.PrintInitTime();
			Console.WriteLine(Object.Equals(instance, instance2));
			Console.WriteLine("-----------------------------------");

			TimeManager.PrintInitTime();
			TimeManager tm = TimeManager.Instance;
			TimeManager.PrintInitTime();
			TimeManager tm2 = new TimeManager();
			TimeManager.PrintInitTime();
			tm2.doSomethings();

			Console.WriteLine(Object.Equals(tm, tm2));
		}
	}
}
