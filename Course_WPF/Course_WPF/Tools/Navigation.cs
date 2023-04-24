using System.Windows.Controls;

namespace Course_WPF.Tools
{
    public class Navigation:BaseVM
    {
        private Navigation() { }

        static Navigation instance = new Navigation();

        public static Navigation Instance => instance;
       
        public Page currentPage { get; set; }

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                Signal();
            }
        }
    }
}
