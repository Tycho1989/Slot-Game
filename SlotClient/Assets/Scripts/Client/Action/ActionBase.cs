/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：ActionBase.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-30
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

/// <summary>
/// 文件名:行为基类
/// 说明:
/// </summary>
public abstract class ActionBase
{

    public abstract void Invoke();

    //中断当前正在执行的行为
    public virtual void Stop()
    {

    }

    //回滚当前行为所执行的操作
    public virtual void Revert()
    {

    }
}
