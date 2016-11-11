using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//备忘录模式:在不破坏封装的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态，这样以后就可以把该对象恢复到原先的状态。
namespace DesignPatterns.Patterns._21_Memento {
	/// <summary>
	/// 联系人
	/// </summary>
	public class ContactPerson {
		public string Name { get; set; }
		public string MobileNum { get; set; }
	}

	/// <summary>
	/// 发起人
	/// </summary>
	public class MobileOwner {
		public List<ContactPerson> ContactPersons { get; set; }
		public MobileOwner(List<ContactPerson> persons) {
			ContactPersons = persons;
		}

		/// <summary>
		/// 创建备忘录，将当期要保存的联系人列表导入到备忘录中 
		/// </summary>
		/// <returns></returns>
		public ContactMemento CreateMemento() {
			return new ContactMemento(new List<ContactPerson>(this.ContactPersons));
		}

		/// <summary>
		/// 将备忘录中的数据备份导入到联系人列表中
		/// </summary>
		/// <param name="memento"></param>
		public void RestoreMemento(ContactMemento memento) {
			if (memento != null) {
				this.ContactPersons = memento.ContactPersonBack;
			}
		}
		public void Show() {
			Console.WriteLine("联系人列表中有{0}个人，他们是:", ContactPersons.Count);
			foreach (ContactPerson p in ContactPersons) {
				Console.WriteLine("姓名: {0} 号码为: {1}", p.Name, p.MobileNum);
			}
		}
	}

	// 备忘录
	public class ContactMemento {
		public List<ContactPerson> ContactPersonBack { get; set; }
		public ContactMemento(List<ContactPerson> persons) {
			ContactPersonBack = persons;
		}
	}

	// 管理角色
	public class Caretaker {
		// 使用多个备忘录来存储多个备份点
		public Dictionary<string, ContactMemento> ContactMementoDic { get; set; }
		public Caretaker() {
			ContactMementoDic = new Dictionary<string, ContactMemento>();
		}
	}

	class MementoTest : IMain {
		public void AppMain() {
			List<ContactPerson> persons = new List<ContactPerson>()
            {
                new ContactPerson() { Name= "Learning Hard", MobileNum = "123445"},
                new ContactPerson() { Name = "Tony", MobileNum = "234565"},
                new ContactPerson() { Name = "Jock", MobileNum = "231455"}
            };

			MobileOwner mobileOwner = new MobileOwner(persons);
			mobileOwner.Show();

			Console.WriteLine("创建备份1...");
			// 创建备忘录并保存备忘录对象
			Caretaker caretaker = new Caretaker();
			caretaker.ContactMementoDic.Add(DateTime.Now.ToString(), mobileOwner.CreateMemento());
			Console.WriteLine();

			// 更改发起人联系人列表
			Console.WriteLine("----移除最后一个联系人--------");
			mobileOwner.ContactPersons.RemoveAt(2);
			mobileOwner.Show();

			// 创建第二个备份
			Console.WriteLine("创建备份2...");
			Thread.Sleep(1000);
			caretaker.ContactMementoDic.Add(DateTime.Now.ToString(), mobileOwner.CreateMemento());
			Console.WriteLine();

			// 恢复到原始状态
			Console.WriteLine("-------恢复联系人列表,请从以下列表选择恢复的日期------");
			var keyCollection = caretaker.ContactMementoDic.Keys;
			foreach (string k in keyCollection) {
				Console.WriteLine("Key = {0}", k);
			}
			while (true) {
				Console.Write("请输入数字,按窗口的关闭键退出:");

				int index = -1;
				try {
					index = Int32.Parse(Console.ReadLine());
				}
				catch {
					Console.WriteLine("输入的格式错误");
					continue;
				}

				ContactMemento contactMentor = null;
				if (index < keyCollection.Count && caretaker.ContactMementoDic.TryGetValue(keyCollection.ElementAt(index), out contactMentor)) {
					mobileOwner.RestoreMemento(contactMentor);
					mobileOwner.Show();
				}
				else {
					Console.WriteLine("输入的索引大于集合长度！");
				}
			}
		}
	}
}