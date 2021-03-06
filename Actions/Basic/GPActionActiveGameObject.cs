﻿//
// GPActionActiveGameObject.cs
//
// Author(s):
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

using Utils;

namespace ActionTool
{	
	[GPActionAlias("Basic/Active GameObject")]
	public class GPActionActiveGameObject : GPAction
	{
		public enum ActivationKind
		{
			ACTIVATE,
			DEACTIVATE,
			SWITCH_ACTIVATION
		}

		#region Public Members

		public ActivationKind _kind;

		public bool _thisObject = false;
		public GameObjectRef _objectRef;

		#endregion
		
		#region GPAction Override
		
		/// <summary>
		/// Raised each time action is triggered
		/// </summary>
		protected override void OnTrigger()
		{
			GameObject obj;

			if(_thisObject)
				obj = this.ParentGameObject;
			else
			{
				if(_objectRef.GameObject == null)
				{
					Debug.LogWarning("Null GameObject will skip action: "+this.EditionName);
					return;
				}

				obj = _objectRef.GameObject;
			}

			switch(_kind)
			{
			case ActivationKind.ACTIVATE:
				obj.SetActive(true);
				break;
			case ActivationKind.DEACTIVATE:
				obj.SetActive(false);
				break;
			case ActivationKind.SWITCH_ACTIVATION:
				obj.SetActive(!obj.activeSelf);
				break;
			}

			End();
		}
	
		#endregion
	}
}
