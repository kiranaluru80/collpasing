using System;
using System.Collections.Generic;
using ConEd.JSSE.Client.ViewModels;
using Xamarin.Forms;

namespace ConEd.JSSE.Client.Views
{
    public partial class GrantPage : ContentPage
    {
        public GrantPage()
        {
            InitializeComponent();
            this.BindingContext = new GrantPageViewModelNew();

		}
		public void OnMore(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			//JSSEInfo obj = mi.CommandParameter as JSSEInfo;
			//DisplayAlert("", obj.jsseId.ToString(), "OK");
		}

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			//JSSEInfo obj = mi.CommandParameter as JSSEInfo;
			//DisplayAlert("", obj.jsseId.ToString(), "OK");
		}
    }
}
