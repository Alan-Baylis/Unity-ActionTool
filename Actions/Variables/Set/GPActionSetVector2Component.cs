﻿//
// GPActionSetVector2Component.cs
//
// Author:
//       Baptiste Dupy <baptiste.dupy@gmail.com>
//
// Copyright (c) 2014 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ActionTool
{
	[GPActionAlias("Variable/Vector2/Set Vector2 Component")]
	public class GPActionSetVector2Component : GPAction
    {
		public enum Vector2Component
		{
			X,
			Y
		}

		public Vector2Component _component;
        public Vector2ValueProvider _variable;
        public FloatValueProvider _newValue;

        protected override void OnTrigger()
        {
			Vector2 v = _variable.GetValue();

			switch(_component)
			{
			case Vector2Component.X:
				v.x = _newValue.GetValue();
				break;
			case Vector2Component.Y:
				v.y = _newValue.GetValue();
				break;
			}

			_variable.SetValue(v);
      		
			End();
        }
    }
}
