using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IRepositoryWrapper
	{
		IAdmin Admin { get; }
		IFriend Friend { get; }
		IMessage Message { get; }
		IMessageCall MessageCall { get; }
		IPostWord PostWord { get; }
		IUser User { get; }
		IPostWordData PostWordData { get; }
		IPostWordDataComment PostWordDataComment { get; }
		ISayHello SayHello { get; }
		void Save();
	}
}
