﻿using System;
namespace CoisadiMae.Util.Extensions
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class EnumDescriptionAttribute : Attribute
	{
		readonly string _description;
		public string Description { get { return _description; } }

		public EnumDescriptionAttribute(string description)
		{
			_description = description;
		}
	}
}