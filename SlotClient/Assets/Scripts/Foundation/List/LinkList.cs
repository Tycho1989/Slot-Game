/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：LinkList.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-30
* 修 改 人：
* 修改日期：
* 描	述：
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;

/// <summary>
/// 文件名:
/// 说明:定义一个泛型单链表类
/// </summary>
public class LinkList<T> : IListDS<T>
{
    #region 字段
    private Node<T> head;   // 单链表头结点
    #endregion

    #region 属性
    // 头结点
    public Node<T> Head
    {
        get
        {
            return head;
        }
        set
        {
            head = value;
        }
    }
    #endregion

    #region 基本操作
    // 构造方法
    public LinkList()
    {
        head = null;
    }

    // 获取单链表的长度
    public int GetLength()
    {
        // 设置指针指向头结点
        Node<T> p = head;

        // 定义存储数据的变量
        int len = 0;

        // 当当前指针指向的地址不是为null时表示存在该结点
        while (p != null)
        {
            len++;
            p = p.Next; // 指针继续指向引用域所指向的结点
        }

        return len;
    }

    // 清空单链表
    // 此处只是将头结点的引用域设置为null的逻辑清空，在内存中数据依旧存在
    // 但是.NET的垃圾回收器会为我们回收这部分垃圾
    public void Clear()
    {
        head = null;
    }

    // 判断单链表是否为空
    public bool IsEmpty()
    {
        // 根据头结点的引用域是否为null判断是否为空
        if (head == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 在单链表尾部追加数据元素
    public bool Append(T item)
    {
        Node<T> node = new Node<T>(item);
        Node<T> p = new Node<T>();

        // 判断此时是否为空表，是则直接修改头结点的引用域
        if (head == null)
        {
            head = node;
        }
        // 不是则遍历结点，找到最后最后一个结点
        else
        {
            p = head;
            while (p.Next != null)
            {
                p = p.Next;
            }

            // 设置最后一个结点的引用域为追加数据元素的地址
            p.Next = node;
        }

        return true;
    }

    // 在单链表的第i个结点的位置前插入一个值为item的结点
    public bool Insert(T item, int i)
    {
        // 判断是否为空表
        if (IsEmpty())
        {
            Console.WriteLine("单链表中不存在数据元素，无法执行插入操作，操作失败！");
            return false;
        }
        // 判断用户指定的插入位置是否合理
        else if (i < 1)
        {
            Console.WriteLine("插入元素的位置不正确，无法执行插入操作，操作失败！");
            return false;
        }
        // 判断是否操作第一个结点
        else if (i == 1)
        {
            // 操作第一个结点
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            return true;
        }
        // 执行一般插入操作
        else
        {
            Node<T> p = head;
            Node<T> pre = new Node<T>();
            int j = 1;

            // 遍历直到当前结点的位置为i
            // 如果插入位置超过单链表长度，则插入失败
            while (p.Next != null && j < i)
            {
                pre = p;
                p = p.Next;
                j++;
            }

            if (j == i)
            {
                Node<T> node = new Node<T>(item);
                node.Next = p;
                pre.Next = node;
                return true;
            }
            else
            {
                Console.WriteLine("插入元素的位置不正确，无法执行插入操作，操作失败！");
                return false;
            }
        }
    }


    // 在单链表的第i个结点的位置后插入一个值为item的结点
    public bool InsertPost(T item, int i)
    {
        // 判断是否为空表
        if (IsEmpty())
        {
            Console.WriteLine("单链表中不存在数据元素，无法执行插入操作，操作失败！");
            return false;
        }
        // 判断用户指定的插入位置是否合理
        else if (i < 1)
        {
            Console.WriteLine("插入元素的位置不正确，无法执行插入操作，操作失败！");
            return false;
        }
        // 判断是否操作第一个结点
        else if (i == 1)
        {
            // 操作第一个结点
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            return true;
        }
        // 执行一般插入操作
        else
        {
            Node<T> p = head;
            Node<T> pre = new Node<T>();
            int j = 1;

            // 遍历直到当前结点的位置为i
            // 如果插入位置超过单链表长度，则插入失败
            while (p.Next != null && j < i)
            {
                pre = p;
                p = p.Next;
                j++;
            }

            if (j == i)
            {
                Node<T> node = new Node<T>(item);
                node.Next = p.Next;
                p.Next = node;
                return true;
            }
            else
            {
                Console.WriteLine("插入元素的位置不正确，无法执行插入操作，操作失败！");
                return false;
            }
        }
    }

    // 删除单链表的第i个结点，只是修改引用域，逻辑上的删除，由垃圾回收器回收
    public T Delete(int i)
    {
        // 定义要返回的元素，并赋初值
        T tmp = default(T);

        // 判断是否为空表
        if (IsEmpty())
        {
            Console.WriteLine("单链表中不存在数据元素，无法执行删除操作，操作失败！");
        }
        // 判断用户指定的删除位置是否合理
        else if (i < 1)
        {
            Console.WriteLine("删除元素的位置不正确，无法执行删除操作，操作失败！");
        }
        // 判断是否操作第一个结点
        else if (i == 1)
        {
            // 操作第一个结点
            Node<T> node = head;
            head = head.Next;
            tmp = node.Data;
        }
        // 执行一般删除操作
        else
        {
            Node<T> node = new Node<T>();
            Node<T> p = head;
            int j = 1;

            while (p.Next != null && j < i)
            {
                node = p;
                p = p.Next;
                j++;
            }

            if (j == i)
            {
                node.Next = p.Next;
                tmp = p.Data;
            }
            else
            {
                Console.WriteLine("删除元素的位置不正确，无法执行删除操作，操作失败！");
            }
        }

        // 返回被操作的元素（或默认值）
        return tmp;
    }

    // 获得单链表中第i个数据元素
    public T GetElem(int i)
    {
        // 定义要返回的元素，并赋初值
        T tmp = default(T);

        // 判断是否为空表
        if (IsEmpty())
        {
            Console.WriteLine("单链表表中不存在数据元素，无法执行获取操作，操作失败！");
        }
        // 判断用户指定的获取位置是否合理
        else if (i < 1)
        {
            Console.WriteLine("获取元素的位置不正确，无法执行获取操作，操作失败！");
        }
        // 执行获取操作，如果位置超过单链表长度，则获得到的为最后一个结点的值
        else
        {
            Node<T> p = new Node<T>();
            p = head;
            int j = 1;

            while (p.Next != null && j < i)
            {
                p = p.Next;
                j++;
            }

            tmp = p.Data;
        }

        // 返回被操作的元素（或默认值）
        return tmp;
    }

    // 在单链表中查找值为value的结点
    public int Locate(T value)
    {
        // 定义要返回的索引，-1表示未找到或查找失败【注意：此处i表示是索引，而非位置！】
        int i;

        // 判断是否为空表
        if (IsEmpty())
        {
            Console.WriteLine("单链表表中不存在数据元素，无法执行查找操作，操作失败！");
            i = -1;
        }
        // 执行查找操作
        else
        {
            Node<T> p = new Node<T>();
            p = head;
            i = 0;
            while (!p.Data.Equals(value) && p.Next != null)
            {
                p = p.Next;
                i++;
            }
        }

        // 返回查找到的索引（或默认值）
        return i;
    }
    #endregion

    #region 高级操作
    // 打印单链表所有结点
    public void PrintAllNode()
    {
        // 判断是否为空表
        if (IsEmpty())
        {
            Console.WriteLine("单链表表中不存在数据元素，无法执行打印操作，操作失败！");
        }
        // 执行打印操作
        else
        {
            Console.WriteLine("打印单链表中的数据元素：\n");
            Node<T> p = new Node<T>();
            p = head;
            while (p.Next != null)
            {
                Console.Write(p.Data + "\t");
                p = p.Next;
            }

            // 打印最后一个结点
            Console.Write(p.Data + "\t");

            Console.WriteLine();
        }
    }

    #endregion
}
