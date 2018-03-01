using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleDB
{
    public partial class UserGroupDetails : ContentPage
    {
        public UserGroupDetails(GetListViewDataModel userObj)
        {
            InitializeComponent();
            gridRef.BindingContext = userObj;

            grantRef.Clicked += (sender, e) => {
                alertViewRef.IsVisible = true;
            };

            alertNoRef.Clicked += (sender, e) => {
                alertViewRef.IsVisible = false;
            };
        }
    }
}
