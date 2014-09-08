using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using System.Collections.Generic;

public class SlgDispatcher :MonoSingleton<SlgDispatcher>
{


		public void send (Command cmd)
		{
				HttpUtil httpUtil = HttpUtil.Instance;
				httpUtil.Post (cmd, this);
		}

		public void handle (Dictionary<string,object> jsonData)
		{
				string mod = jsonData ["mod"].ToString ();
				string act = jsonData ["act"].ToString ();
				string serviceName = mod.Substring (0, 1).ToUpper () + mod.Substring (1) + "Service";
				string actName = act + "Handler";
				Assembly ass = Assembly.GetExecutingAssembly ();
				Type type = ass.GetType (serviceName, true);

				PropertyInfo propertyInfo = type.BaseType.GetProperty ("Instance");
				System.Object o = propertyInfo.GetValue (null, null);
				MethodInfo methodInfo = type.GetMethod (actName);
				Dictionary<string,object> data = jsonData ["data"] as Dictionary<string,object>;
				Dictionary<string,object> args = jsonData ["args"] as Dictionary<string,object>;
				methodInfo.Invoke (o, new System.Object[]{args,data});
		}

}
