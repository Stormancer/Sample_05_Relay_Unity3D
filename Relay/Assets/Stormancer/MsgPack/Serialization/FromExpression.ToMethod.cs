﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2012 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace MsgPack.Serialization
{
	// This file generated from FromExpression.tt T4Template.
	// Do not modify this file. Edit FromExpression.tt instead.

	partial class FromExpression 
	{
		public static MethodInfo ToMethod<T>( Expression< System.Action<T> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod( Expression< System.Action > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T1, T2>( Expression< System.Action<T1, T2> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T1, T2, T3>( Expression< System.Action<T1, T2, T3> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T1, T2, T3, T4>( Expression< System.Action<T1, T2, T3, T4> > source )
		{
			return ToMethodCore( source );
		}

		public static MethodInfo ToMethod<TResult>( Expression< System.Func<TResult> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T, TResult>( Expression< System.Func<T, TResult> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T1, T2, TResult>( Expression< System.Func<T1, T2, TResult> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T1, T2, T3, TResult>( Expression< System.Func<T1, T2, T3, TResult> > source )
		{
			return ToMethodCore( source );
		}
		public static MethodInfo ToMethod<T1, T2, T3, T4, TResult>( Expression< System.Func<T1, T2, T3, T4, TResult> > source )
		{
			return ToMethodCore( source );
		}
	}
}

