using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._15_Observer {

	/// <summary>
	/// 主题
	/// </summary>
	class WeiXinOAInNet {
		public string Name { get; set; }

		public WeiXinOAInNet(string name) {
			this.Name = name;
			Console.WriteLine("创建公众号： {0}",this.Name);
		}

		public delegate void ShareEventHandler(Object sender, ShareEventArgs e);
		public event ShareEventHandler Share;

		protected virtual void OnShare(ShareEventArgs e) {
			if (Share != null) {
				Share(this, e);
			}
		}

		public void SendShareMessage(string msg) {
			OnShare(new ShareEventArgs(msg));
		}

		public class ShareEventArgs : EventArgs {
			public readonly string newMessage;
			public ShareEventArgs(string msg) {
				this.newMessage = msg;
			}
		}
	}

	/// <summary>
	/// 观察者
	/// </summary>
	class WeiXinUserInNet {
		public string  Name { get; set; }
		public WeiXinUserInNet(string name) {
			this.Name = name;
			Console.WriteLine("创建微信用户： {0}", this.Name);

		}

		public void UpdateMessage(Object sender,WeiXinOAInNet.ShareEventArgs e) {
			WeiXinOAInNet oa= sender as WeiXinOAInNet;
			Console.WriteLine("公众号 {0} 为 {1} 发来了消息：{2}",oa.Name,this.Name,e.newMessage);
		}
	}

	class ObserverTest2 : IMain {

		public void AppMain() {
			WeiXinUserInNet user1 = new WeiXinUserInNet("Jimme");
			WeiXinUserInNet user2 = new WeiXinUserInNet("Elle");
			Console.WriteLine();
			WeiXinOAInNet oa = new WeiXinOAInNet("C# Test");
			Console.WriteLine("开始关注");
			oa.Share += user1.UpdateMessage;
			oa.Share += user2.UpdateMessage;
			Console.WriteLine();

			oa.SendShareMessage("大家好！");

			Console.WriteLine("Jimme取消关注");
			oa.Share -= user1.UpdateMessage;
			oa.SendShareMessage("下午好！");

		}
	}
}
