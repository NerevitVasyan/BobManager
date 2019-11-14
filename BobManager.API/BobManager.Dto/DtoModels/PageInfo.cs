using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class PageInfo
    {
        private const int DEFAULT_PAGE = 1;
        private const int PAGE_ITEMS = 5;
        private int currentPage = 1;
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; } = PAGE_ITEMS;
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value > 0 && value <= TotalPages ? value : DEFAULT_PAGE;
            }
        }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}