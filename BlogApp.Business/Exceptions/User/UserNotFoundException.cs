﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.User
{
	public class UserNotFoundException : Exception
	{
		public UserNotFoundException() : base("UserName / Email or Password is Wrong !") { }
		

		public UserNotFoundException(string? message) : base(message)
		{
		}
	}
}
