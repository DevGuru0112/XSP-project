//
// EnumSetting.cs
//
// Author:
//   Leonardo Taglialegne <leonardo.taglialegne@gmail.com>
//
// Copyright (c) 2013 Leonardo Taglialegne.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Mono.WebServer.Options.Settings {
	public class EnumSetting<T> : Setting<T> where T : struct 
	{
		static bool EnumParser<TEnum> (string input, out TEnum output)
		{
			output = default (TEnum);
			try {
				output = (TEnum)Enum.Parse (typeof (TEnum), input, true);
				return true;
			} catch (ArgumentException) { // TODO: catch more specific type
				return false;
			}
		}

		public EnumSetting (string name, string description, string appSetting = null, string environment = null, T defaultValue = default(T), string prototype = null)
			: base (name, EnumParser, description, appSetting, environment, defaultValue, prototype)
		{
		}
	}
}
