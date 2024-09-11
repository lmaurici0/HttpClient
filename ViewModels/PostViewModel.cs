using CommunityToolkit.Mvvm.ComponentModel;
using AppPostService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPostService.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace AppPostService.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts;


        public ICommand getPostCommand { get; set; }
        public PostViewModel()
        {
            getPostCommand = new Command(getPosts);
        }

        public async void getPosts()
        {
            PostService postService = new PostService();
            Posts = await postService.getPosts();
        }

    }
}
