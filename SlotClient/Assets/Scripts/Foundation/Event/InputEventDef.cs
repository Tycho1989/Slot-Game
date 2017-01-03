/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：InputEventDef.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-4
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

public delegate void Callback();
public delegate void Callback<T0>(T0 arg0);
public delegate void Callback<T0,T1>(T0 arg0,T1 arg1);
public delegate void Callback<T0,T1,T2>(T0 arg0,T1 arg1,T2 arg2);
