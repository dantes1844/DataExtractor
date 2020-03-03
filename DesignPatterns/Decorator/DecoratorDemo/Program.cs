using System;

namespace DecoratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            LibraryItem book = new Book("CLR Via C#","Geffery",10);
            book.Display();

            LibraryItem video = new Video("英雄","张艺谋",100,20);
            video.Display();

            Borrowable d = new Borrowable(book);
            d.Borrow("yujian");
            d.Display();

            d.Borrow("laobai");
            d.Display();

            d.ReturnItem("yujian");
            d.Display();

            #region 输出
            /*
                    当前书籍名称:CLR Via C#
                    当前书籍作者:Geffery
                    当前书籍剩余数量:10
                    ----------------------------------------
                    当前电影名称:《英雄》
                    当前电影导演:《张艺谋》
                    当前电影播放次数:100次
                    当前电影剩余数量:20
                    ----------------------------------------
                    当前书籍名称:CLR Via C#
                    当前书籍作者:Geffery
                    当前书籍剩余数量:9
                    ----------------------------------------
                    借阅者是:yujian
                    ----------------------------------------
                    当前书籍名称:CLR Via C#
                    当前书籍作者:Geffery
                    当前书籍剩余数量:8
                    ----------------------------------------
                    借阅者是:yujian
                    借阅者是:laobai
                    ----------------------------------------
                    当前书籍名称:CLR Via C#
                    当前书籍作者:Geffery
                    当前书籍剩余数量:9
                    ----------------------------------------
                    借阅者是:laobai
                    ----------------------------------------

                 */ 
            #endregion

            Console.ReadKey();
        }
    }
}
