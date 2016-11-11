using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//原型模式:只创建一个类实例对象，如果后面需要更多这样的实例，可以通过对原来对象拷贝一份来完成创建
//这样在内存中不需要创建多个相同的类实例，从而减少内存的消耗和达到类实例的复用。
namespace DesignPatterns.Patterns._04_Prototype {
	class PrototypeTest:IMain {
		interface IDoppelganger {
			bool isRoot { get; set; }
			IDoppelganger doppelganger();
		}

		class Naruto : IDoppelganger {

			public bool isRoot { get; set; }

			public Naruto() {
				isRoot = true;
			}

			public IDoppelganger doppelganger() {
				if (!isRoot) {
					return null;
				}
				var cloneObj=(Naruto)this.MemberwiseClone();
				cloneObj.isRoot=false;
				return cloneObj;
			}
		}

		public void AppMain() {
			Naruto naruto = new Naruto();
			Console.WriteLine(naruto.isRoot);
			Console.WriteLine();
			var narutoDoppelganger = naruto.doppelganger();
			Console.WriteLine(naruto.isRoot);
			Console.WriteLine(narutoDoppelganger.isRoot);
		}
	}
}
