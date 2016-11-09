using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Patterns._01_Factory._Base;
using DesignPatterns.Patterns._Base;

namespace DesignPatterns.Patterns._01_Factory.Abstract_Factory {


	/// <summary>
	/// Abstract Factory
	/// 提供一个接口用于创建一系列相互关联或者相互依赖的对象，而不需要指定它们的实体类。
	/// </summary>
	class AbstractFactoryTest:IMain {
		//定义构成身体部件的接口
		interface IHead { string name { get; } }
		interface IStature { string name { get; } }
		interface ISkin { string name { get; } }

		//人类部件
		class HumanHead : IHead {
			public string name {
				get { return "Human Head."; }
			}
		}
		class HumanStature : IStature {
			public string name {
				get { return "Human Stature."; }
			}
		}
		class HumanSkin : ISkin {
			public string name {
				get { return "Human Skin."; }
			}
		}

		//精灵部件
		class EifHead : IHead {
			public string name {
				get { return "Eif Head."; }
			}
		}
		class EifStature : IStature {
			public string name {
				get { return "Eif Stature."; }
			}
		}
		class EifSkin : ISkin {
			public string name {
				get { return "Eif Skin."; }
			}
		}

		/// <summary>
		/// 身体部件工厂接口
		/// </summary>
		interface IRacePartsFactory {
			IHead CreateHead();
			IStature CreateStature();
			ISkin CreateSkin();
		}

		/// <summary>
		/// 人类部件工厂
		/// </summary>
		class HumanPartsFactory : IRacePartsFactory {
			public IHead CreateHead() {
				return new HumanHead();
			}

			public IStature CreateStature() {
				return new HumanStature();
			}

			public ISkin CreateSkin() {
				return new HumanSkin();
			}
		}

		/// <summary>
		/// 精灵部件工厂
		/// </summary>
		class EifPartsFactory : IRacePartsFactory {
			public IHead CreateHead() {
				return new EifHead();
			}

			public IStature CreateStature() {
				return new EifStature();
			}

			public ISkin CreateSkin() {
				return new EifSkin();
			}
		}

		
		/// <summary>
		/// 角色类
		/// </summary>
		class Race {
			public IHead Head;
			public IStature Stature;
			public ISkin Skin;

			public Race(IRacePartsFactory raceFactory) {
				this.Head = raceFactory.CreateHead();
				this.Stature = raceFactory.CreateStature();
				this.Skin = raceFactory.CreateSkin();
			}

			public void ShowParts(){
				Console.WriteLine(this.Head.name);
				Console.WriteLine(this.Stature.name);
				Console.WriteLine(this.Skin.name);
			}
		}

		public void AppMain() {
			Console.WriteLine("create elf");
			Race elf = new Race(new EifPartsFactory());
			elf.ShowParts();
			Console.WriteLine("\ncreate human");
			Race human = new Race(new HumanPartsFactory());
			human.ShowParts();
		}
	}
}
