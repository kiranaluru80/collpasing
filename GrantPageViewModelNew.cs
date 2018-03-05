using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ConEd.JSSE.Client.Common;
using ConEd.JSSE.Client.Models;
using Xamarin.Forms;

namespace ConEd.JSSE.Client.ViewModels
{
    public class GrantPageViewModelNew : INotifyPropertyChanged     {          public class JSSEInfo         {             public int jsseId { get; set; }             public string jsseStatus { get; set; }             public string jsseDate { get; set; }         }          public event PropertyChangedEventHandler PropertyChanged;         // public ObservableCollection<Group> GroupItems { get; set; }


        private ObservableCollection<Group> _groupItems;
        public ObservableCollection<Group> GroupItems
        {
            get { return _groupItems; }
            set
            {
                if (Equals(value, _groupItems)) return;
                _groupItems = value;
                OnPropertyChanged(nameof(GroupItems));
            }
        }            public int SelectedGroupId;           private ObservableCollection<GetListViewDataModel> _listeviewItemSource = new ObservableCollection<GetListViewDataModel>();          public ObservableCollection<GetListViewDataModel> ListeviewItemSource         {             get { return _listeviewItemSource; }         } 
        public GrantPageViewModelNew()         {
                         List<Group> sortingGroup = new List<Group>();
            Group obj = new Group();
            obj.GroupName = "one";

            Group obj1 = new Group();
            obj1.GroupName = "two";

            Group obj2 = new Group();
            obj2.GroupName = "three";

            Group obj3 = new Group();
            obj3.GroupName = "four";

            Group obj4 = new Group();
            obj4.GroupName = "five";

            sortingGroup.Add(obj);
            sortingGroup.Add(obj1);
            sortingGroup.Add(obj2);
            sortingGroup.Add(obj3);
            sortingGroup.Add(obj4);

           // GroupItems = sortingGroup;
 
            var getREST = ServiceBusRelay.GetAsync<GrantModel>(constantfile.GetGrantMajorGrup + "jarugulav").ContinueWith((taskresponse) =>

                     {
                         var stringres = taskresponse;
                         stringres.Wait();

                         GrantModel userGroupModel = stringres.Result;

                         //   GrantModel userGroupModel = JsonConvert.DeserializeObject<GrantModel>(taskresponse.);

                         ObservableCollection<Group> sortingGroupobj = new ObservableCollection<Group>();
                         for (int i = 0; i < userGroupModel.Groups.Count; i++)
                         {
                             if (userGroupModel.Groups[i].GroupType.Level_Id == 2)
                             {
                                 sortingGroupobj.Add(userGroupModel.Groups[i]);
                             }
                         }

                         //GroupItems = sortingGroupobj;

                         //Device.BeginInvokeOnMainThread(() =>
                         //{
                         //    GroupItems = sortingGroupobj;
                         //});

                         Device.BeginInvokeOnMainThread(() =>
                         {
                             // do the UI change
                             GroupItems = sortingGroupobj;
                         });

                     });


        }          public void getListViewData()
        {              //var assembly = typeof(DynamicScreen).GetTypeInfo().Assembly;             //Stream stream = assembly.GetManifestResourceStream("SampleDB.getGroupData.json");             //using (var reader = new System.IO.StreamReader(stream))             //{              //    var json = reader.ReadToEnd();             //    List<GetListViewDataModel> userGroupModel = JsonConvert.DeserializeObject<List<GetListViewDataModel>>(json);             //    List<User> groupList = new List<User>();             //    for (int i = 0; i < userGroupModel.Count; i++)             //    {             //        ListeviewItemSource.Add(userGroupModel[i]);             //    }              //}

        }          Group selectedGroup;         public Group SelectedGroup         {             get { return selectedGroup; }             set             {                 if (selectedGroup != value)                 {                     selectedGroup = value;                     SelectedGroupId = selectedGroup.Group_ID;                     OnPropertyChanged("selectedGroup");                 }             }         }          protected virtual void OnPropertyChanged(string propertyName)         {             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));         }     } }  