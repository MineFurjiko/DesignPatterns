using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._16_Mediator {
	class Latter {
		public ICommunicate Author { get; set; }

		public ICommunicate Target { get; set; }
		private string content;
		public Latter(ICommunicate author, ICommunicate target, string content) {
			this.Author = author;
			this.Target = target; 
			this.content = content;
		}

		public void  ReadContent(){
			Console.WriteLine(content);
		}
	}

	interface ICommunicate{
		string PenName { get; set; }
		List<Latter> Outbox { get;  }
		List<Latter> MessageBox { get;  }
		void SendLatter(Latter latter, IExpress messenger);
		void AcceptLatter(Latter latter);
		void ReadLatter();
	}

	interface IExpress {
		void Express(Latter latter);
	}

	class Chinese : ICommunicate {
		private List<Latter> outBox = new List<Latter>();
		private List<Latter> messageBox = new List<Latter>();
		public string PenName { get; set; }

		public Chinese(string name) {
			this.PenName = name;
		}

		public List<Latter> Outbox {
			get { return this.outBox; }
		}

		public List<Latter> MessageBox {
			get { return this.messageBox; }
		}

		public void SendLatter(Latter latter, IExpress messenger) {
			Console.WriteLine("呼叫信使...");
			Console.WriteLine("信使接受信件...");

			messenger.Express(latter);

		}

		public void AcceptLatter(Latter latter) {
			Console.WriteLine("收到来自 {0} 的信件...",latter.Author.PenName);
			this.messageBox.Add(latter);
		}

		public void ReadLatter() {
			foreach (var item in messageBox) {
				item.ReadContent();
			}
		}

		
	}

	class Japanese : ICommunicate {
		private List<Latter> outBox = new List<Latter>();
		private List<Latter> messageBox = new List<Latter>();
		public string PenName { get; set; }
		public Japanese(string name) {
			this.PenName = name;
		}

		public List<Latter> Outbox {
			get { return this.outBox; }
		}

		public List<Latter> MessageBox {
			get { return this.messageBox; }
		}

		public void SendLatter(Latter latter, IExpress messenger) {
			Console.WriteLine("宅配便を呼び出す...");
			Console.WriteLine("宅配便受付郵便サービス...");

			messenger.Express(latter);
		}

		public void AcceptLatter(Latter latter) {
			Console.WriteLine("{0} の手紙を受け取った...", latter.Author.PenName);
			this.messageBox.Add(latter);
		}

		public void ReadLatter() {
			foreach (var item in messageBox) {
				item.ReadContent();
			}
		}
	}

	class Messenger : IExpress {

		public void Express( Latter latter) {
			Console.WriteLine("信使正在为 {0} 寄送信件给 {1}",latter.Author.PenName,latter.Target.PenName);
			Thread.Sleep(500);
			latter.Target.AcceptLatter(latter);
		}
	}



	class MediatorTest:IMain {
		public void AppMain() {
			IExpress messenger = new Messenger();
			Chinese cp = new Chinese("小张");
			Japanese jp = new Japanese("柚木缇娜");

			cp.SendLatter(new Latter(cp, jp, "Hello!"), messenger);
			jp.ReadLatter();
			Console.WriteLine();

			Thread.Sleep(1000);
			cp.SendLatter(new Latter(cp, jp, "New Message!"), messenger);
			jp.ReadLatter();
			Console.WriteLine();

			Thread.Sleep(1000);
			jp.SendLatter(new Latter(jp,cp,"My return Message!"),messenger);
			cp.ReadLatter();
		}
	}
}
