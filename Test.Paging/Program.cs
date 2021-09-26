using System;

namespace Test.Paging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("전체 데이터 개수를 입력하세요 : ");
            int totalItems = int.Parse(Console.ReadLine());

            //DisplayPagingGroupInfo(totalItems);
            DisplayStartPageInfo(totalItems);

            Console.ReadLine();
        }

        private static void DisplayPagingGroupInfo(int totalItems)
        {
            Console.WriteLine("페이지 데이터 개수를 입력하세요 : ");
            int itemsPerPage = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            // dataNo

            for(int dataNo = 1; dataNo <= totalItems; dataNo++)
            {
                int pagingGroup = (int)Math.Ceiling((decimal)dataNo / itemsPerPage);

                Console.WriteLine("dataNo / itemsPerPage = pagingGroup" +
                                  $" => {dataNo} / {itemsPerPage} = {pagingGroup}");
            }
        }

        private static void DisplayStartPageInfo(int totalItems)
        {
            // CurrentPage

            Console.Write("페이지 숫자링크 개수를 입력하세요 : ");
            int numberLinksPerPage = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            for(int currentPage = 1; currentPage <= totalItems; currentPage++)
            {
                int pagingGroup = (int)Math.Ceiling((decimal)currentPage / numberLinksPerPage);
                int startPage = (pagingGroup * numberLinksPerPage) - numberLinksPerPage + 1;

                Console.WriteLine("(pagingGroup * numberLinksPerPage)" +
                                  " - numberLinksPerPage + 1 = startPage => " +
                                  $"({pagingGroup}*{numberLinksPerPage})" +
                                  $"- {numberLinksPerPage} + 1 = {startPage}");
            }
        }
    }
}
