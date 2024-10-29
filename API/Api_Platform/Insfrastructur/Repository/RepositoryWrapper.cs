using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Insfrastructur.Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private AppDbContext DB;

		public RepositoryWrapper(AppDbContext _db)
		{
			DB = _db;
		}

		private IAdmin _admin;
		private IFriend _friend;
		private IMessage _message;
		private IMessageCall _messagecall;
		private IPostWord _postword;
		private IUser _user;
		private IPostWordData _postworddata;
		private IPostWordDataComment _postworddatacomment;
		private ISayHello _sayhello;

		public IAdmin Admin
		{
			get
			{
				if (_admin == null)
				{
					_admin = new AdminRepository(DB);
				}
				return _admin;
			}
		}

		public IFriend Friend
		{
			get
			{
				if (_friend == null)
				{
					_friend = new FriendRepository(DB);
				}
				return _friend;
			}
		}

		public IMessage Message
		{
			get
			{
				if (_message == null)
				{
					_message = new MessageRepository(DB);
				}
				return _message;
			}
		}

		public IMessageCall MessageCall
		{
			get
			{
				if (_messagecall == null)
				{
					_messagecall = new MessageCallRepository(DB);
				}
				return _messagecall;
			}
		}

		public IPostWord PostWord
		{
			get
			{
				if (_postword == null)
				{
					_postword = new PostWordRepository(DB);
				}
				return _postword;
			}
		}

		public IUser User
		{
			get
			{
				if (_user == null)
				{
					_user = new UserRepository(DB);
				}
				return _user;
			}
		}

		public IPostWordData PostWordData
		{
			get
			{
				if (_postworddata == null)
				{
					_postworddata = new PostWordDataRepository(DB);
				}
				return _postworddata;
			}
		}

		public IPostWordDataComment PostWordDataComment
		{
			get
			{
				if (_postworddatacomment == null)
				{
					_postworddatacomment = new PostWordDataCommentRepository(DB);
				}
				return _postworddatacomment;
			}
		}

		public ISayHello SayHello
		{
			get
			{
				if (_sayhello == null)
				{
					_sayhello = new SayHelloRepository(DB);
				}
				return _sayhello;
			}
		}


		public void Save()
		{
			DB.SaveChanges();
		}

	}
}
