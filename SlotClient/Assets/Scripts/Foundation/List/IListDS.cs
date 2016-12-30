/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：IListDS.cs
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
/// 说明:定义一个泛型线性表表的接口
/// </summary>
public interface IListDS<T>
{
    int GetLength();    // 求线性表的长度（数据元素的个数）
    void Clear();   // 清空线性表中的数据元素
    bool IsEmpty(); // 判断线性表是否为空（空表）
    bool Append(T item);    // 附加一个数据元素到线性表的尾部
    bool Insert(T item, int i); // 在线性表位置i处插入数据元素
    T Delete(int i);    // 删除线性表位置i的数据元素，并返回被删除的数据元素
    T GetElem(int i);   // 取得线性表位置i的数据元素
    int Locate(T value);    // 按值查找在线性表中首个符合条件的数据元素
}
