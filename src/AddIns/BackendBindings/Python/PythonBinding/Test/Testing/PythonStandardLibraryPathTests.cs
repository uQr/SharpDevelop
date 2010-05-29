﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using ICSharpCode.PythonBinding;
using NUnit.Framework;

namespace PythonBinding.Tests.Testing
{
	[TestFixture]
	public class PythonStandardLibraryPathTests
	{
		[Test]
		public void PathsPropertyReturnsPython26LibDirectory()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(@"c:\python26\lib");
			string[] expectedPaths = new string[] { @"c:\python26\lib" };
			Assert.AreEqual(expectedPaths, path.Directories);
		}
		
		[Test]
		public void HasPathReturnsTrueForNonEmptyPathString()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(@"c:\python26\lib");
			Assert.IsTrue(path.HasPath);
		}
		
		[Test]
		public void HasPathReturnsFalseForEmptyPathString()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(String.Empty);
			Assert.IsFalse(path.HasPath);
		}
		
		[Test]
		public void DirectoryPropertyReturnsPython26LibDirectoryAndPython26LibTkDirectory()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(@"c:\python26\lib;c:\python26\lib\lib-tk");
			string[] expectedPaths = new string[] { @"c:\python26\lib", @"c:\python26\lib\lib-tk" };
			Assert.AreEqual(expectedPaths, path.Directories);
		}
		
		[Test]
		public void DirectoryPropertyReturnsPython26LibDirectoryAndPython26LibTkDirectorySetInPathProperty()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(String.Empty);
			path.Path = @"c:\python26\lib;c:\python26\lib\lib-tk";
			string[] expectedPaths = new string[] { @"c:\python26\lib", @"c:\python26\lib\lib-tk" };
			Assert.AreEqual(expectedPaths, path.Directories);
		}
		
		[Test]
		public void DirectoriesAreClearedWhenPathIsSetToDifferentValue()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(@"c:\temp");
			path.Path = @"c:\python26\lib;c:\python26\lib\lib-tk";
			string[] expectedPaths = new string[] { @"c:\python26\lib", @"c:\python26\lib\lib-tk" };
			Assert.AreEqual(expectedPaths, path.Directories);
		}
		
		[Test]
		public void EmptyDirectoryInPathNotAddedToDirectories()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(@"c:\temp;;c:\python\lib");
			string[] expectedPaths = new string[] { @"c:\temp", @"c:\python\lib" };
			Assert.AreEqual(expectedPaths, path.Directories);
		}
		
		[Test]
		public void DirectoryWithJustWhitespaceIsNotAddedToPath()
		{
			PythonStandardLibraryPath path = new PythonStandardLibraryPath(@"c:\temp;    ;c:\python\lib");
			string[] expectedPaths = new string[] { @"c:\temp", @"c:\python\lib" };
			Assert.AreEqual(expectedPaths, path.Directories);
		}
	}
}
