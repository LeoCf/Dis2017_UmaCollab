﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umaCollabApp.entities;
using umaCollabApp.Entities;
using umaCollabApp.Interfaces;
using umaCollabApp.ViewModel.Teams;
using Xamarin.Forms;


namespace umaCollabApp.Views.Teams
{
    public partial class SelectMemberListPage : IMessage
    {

        public SelectMemberListPage(Team currentItem)
        {

            InitializeComponent();
            var viewModel = new SelectMemberListViewModel(currentItem);
            viewModel.Message = this;
            viewModel.Navigation = this.Navigation;

            BindingContext = viewModel;
        }
    }
}
