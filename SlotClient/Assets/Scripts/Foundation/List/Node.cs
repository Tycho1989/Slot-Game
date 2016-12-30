/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：Node.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-30
* 修 改 人：
* 修改日期：
* 描	述：
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

/// <summary>
/// 文件名:
/// 说明:定义一个泛型单链表结点类
/// </summary>
public class Node<T>
{
    #region 字段
    private T data; // 数据域
    private Node<T> next;   // 引用域
    #endregion

    #region 属性
    // 数据域
    public T Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }

    // 引用域
    public Node<T> Next
    {
        get
        {
            return next;
        }
        set
        {
            next = value;
        }
    }
    #endregion

    #region 构造方法
    // 包含数据域和引用域的结点
    public Node(T val, Node<T> p)
    {
        data = val;
        next = p;
    }

    // 只包含引用域的结点
    public Node(Node<T> p)
    {
        next = p;
    }

    // 只包含数据域的结点
    public Node(T val)
    {
        data = val;
        next = null;
    }

    // 既不包含数据域也不包含引用域的结点
    public Node()
    {
        data = default(T);
        next = null;
    }
    #endregion
}
