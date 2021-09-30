using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAMA.V7.Utils
{
    public class PagingInfo
    {
        /// <summary>
        /// 검색전 총 데이터 수
        /// </summary>
        public int TotalEntries { get; set; }

        /// <summary>
        /// 검색후 총 데이터 수
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// 페이지 숫자링크 개수
        /// </summary>
        public int NumberLinksPerPage { get; set; }

        /// <summary>
        /// 현재페이지
        /// </summary>
        [Required(ErrorMessage = "현재 페이지 정보를 입력하세요.")]
        [Range(1, int.MaxValue, ErrorMessage = "현재 페이지는 {1}페이지 이상입니다.")]
        public int CurrentPage { get; set; }

        /// <summary>
        /// 총 페이지 수
        /// </summary>
        public int TotalPage
            => ItemsPerPage < 1 ? ItemsPerPage : (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        /// <summary>
        /// 시작 페이지
        /// </summary>
        public int StartPage { get; set; }

        /// <summary>
        /// 마지막 페이지
        /// </summary>
        public int EndPage {  get; set; }

        /// <summary>
        /// 페이지 데이터 개수
        /// </summary>
        [Required(ErrorMessage = "페이지 데이터 개수 정보를 입력하세요.")]
        [Range(1, int.MaxValue, ErrorMessage = "페이지 데이터 개수는 {1}개 이상입니다.")]
        public int ItemsPerPage {  get; set; }

        /// <summary>
        /// 현재페이지 첫 데이터번호
        /// </summary>
        public int FirstItem { get; set; }

        /// <summary>
        /// 현재페이지 마지막 데이터번호
        /// </summary>
        public int LastItem { get; set;  }

        /// <summary>
        /// 검색명
        /// </summary>
        public string SearchName { get; set; }
    }
}
