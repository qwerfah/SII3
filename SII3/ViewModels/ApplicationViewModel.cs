using SII3.Helpers;
using SII3.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SII3.ViewModels
{
    /// <summary> ViewModel для MainView. </summary>
    public partial class ApplicationViewModel : Observable
    {
        private Tree _memoryTree;
        private ObservableCollection<TreeViewItem> _memoryTreeViewItems;

        private ObservableCollection<User> _users;
        private ObservableCollection<ListViewItem> _userItems;

        private User _currentUser;

        private ObservableCollection<TreeViewItem> _favouriteItems;
        private ObservableCollection<TreeViewItem> _notShowItems;

        private ObservableCollection<Node> _recommendations;
        private ObservableCollection<TreeViewItem> _recommendationsItems;

        /// <summary> Дерево типов памяти. </summary>
        public Tree MemoryTree
        {
            get => _memoryTree;
            set => Set(ref _memoryTree, value);
        }
        /// <summary> TreeView для отображения дерева типов памяти. </summary>
        public ObservableCollection<TreeViewItem> MemoryTreeViewItems
        {
            get => _memoryTreeViewItems;
            set => Set(ref _memoryTreeViewItems, value);
        }
        /// <summary> Список пользователей системы. </summary>
        public ObservableCollection<User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }
        /// <summary> Список пользователей системы (ListView). </summary>
        public ObservableCollection<ListViewItem> UserItems
        {
            get => _userItems;
            set => Set(ref _userItems, value);
        }
        /// <summary> Текущий выбранный пользователь. </summary>
        public User CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }
        /// <summary> Список сохраненных элементов текущего пользователя. </summary>
        public ObservableCollection<TreeViewItem> FavouriteItems
        {
            get => _favouriteItems;
            set => Set(ref _favouriteItems, value);
        }
        /// <summary> Список элементов текущего пользователя, помеченных как "больше не придлагать" (ListView). </summary>
        public ObservableCollection<TreeViewItem> NotShowItems
        {
            get => _notShowItems;
            set => Set(ref _notShowItems, value);
        }
        /// <summary> Список рекомендаций текущего пользователя. </summary>
        public ObservableCollection<Node> Recommendations
        {
            get => _recommendations;
            set => Set(ref _recommendations, value);
        }
        /// <summary> Список рекомендаций текущего пользователя (ListView). </summary>
        public ObservableCollection<TreeViewItem> RecommendationsItems
        {
            get => _recommendationsItems;
            set => Set(ref _recommendationsItems, value);
        }

        private string _filename = "";
        private string _userName = "";
        private string _currentUserName = "";
        private string _usersCount = "5";

        /// <summary> Путь к JSON-файлу с деревом. </summary>
        public string Filename
        {
            get => _filename;
            set => Set(ref _filename, value);
        }
        /// <summary> Имя пользователя (поле ввода). </summary>
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }
        /// <summary> Имя текущего пользователя системы. </summary>
        public string CurrentUserName
        {
            get => _currentUserName;
            set => Set(ref _currentUserName, value);
        }
        /// <summary> Число пользователей при подборе рекомендаций. </summary>
        public string UsersCount
        {
            get => _usersCount;
            set => Set(ref _usersCount, value);
        }

        public ApplicationViewModel()
        {
            Users = new ObservableCollection<User>();
            
            UserItems = new ObservableCollection<ListViewItem>();
            FavouriteItems = new ObservableCollection<TreeViewItem>();
            RecommendationsItems = new ObservableCollection<TreeViewItem>();

            LoadTreeFromFile();

            var user = new User("user1");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR3-800"),
                MemoryTree.GetNode("DDR3-1066"),
                MemoryTree.GetNode("DDR3-1333"),
                MemoryTree.GetNode("DDR3-1600"),
            };
            AddUser(user);

            user = new User("user2");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR3-1066"),
                MemoryTree.GetNode("DDR3-1333"),
                MemoryTree.GetNode("DDR3-1600"),
                MemoryTree.GetNode("DDR3-1866"),
                MemoryTree.GetNode("DDR3-2133"),
            };
            AddUser(user);

            user = new User("user3");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR4-1600"),
                MemoryTree.GetNode("DDR4-1866"),
                MemoryTree.GetNode("DDR3-1866"),
                MemoryTree.GetNode("DDR3-2133"),
            };
            AddUser(user);

            user = new User("user4");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR4-1600"),
                MemoryTree.GetNode("DDR4-1866"),
                MemoryTree.GetNode("DDR3-1600"),
            };
            AddUser(user);

            user = new User("user5");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR4-1600"),
                MemoryTree.GetNode("DDR4-1866"),
                MemoryTree.GetNode("DDR3-1066"),
            };
            AddUser(user);

            user = new User("user6");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR4-1600"),
            };
            AddUser(user);

            user = new User("user7");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DDR4-2666"),
                MemoryTree.GetNode("DDR4-2933"),
            };
            AddUser(user);

            user = new User("user8");
            user.Favourite = new List<Node>
            {
                MemoryTree.GetNode("DRAM"),
                MemoryTree.GetNode("DDR3-1066"),
            };
            AddUser(user);
        }
    }
}
