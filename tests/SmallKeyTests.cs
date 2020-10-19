using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BinaryRage.UnitTests
{
	[TestFixture]
	public class SmallKeyTests
	{
		const string DB_NAME = "SmallKeyTests";

		[SetUp]
		public void Setup()
		{
			if (Directory.Exists(DB_NAME))
				Directory.Delete(DB_NAME, recursive: true);
		}

		/// <summary>
		/// Regression test to ensure that issue 
		/// "Key length less than 4 makes infinite loop"
		/// is not re-introduced.
		/// </summary>
		[Test]
		public void MustAcceptSmallKey()
		{
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BinaryRage.DB.Get<Model>("123", filelocation: "SmallKeyTests"));
		}
	}
}
