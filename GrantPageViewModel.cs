using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using ConEd.JSSE.Client.Common;
using ConEd.JSSE.Client.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ConEd.JSSE.Client.ViewModels
{
    public class GrantPageViewModel : ViewModelBase
    {
        public class JSSEInfo
        {
            public int jsseId { get; set; }
            public string jsseStatus { get; set; }
            public string jsseDate { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        }



        public int SelectedGroupId;


        private ObservableCollection<GetListViewDataModel> _listeviewItemSource = new ObservableCollection<GetListViewDataModel>();

        public ObservableCollection<GetListViewDataModel> ListeviewItemSource
        {
            get { return _listeviewItemSource; }
        }


        public GrantPageViewModel()
        {

           /* List<Group> sortingGroup = new List<Group>();

            Group obj = new Group();
            obj.GroupName = "one";

            Group obj1 = new Group();
            obj.GroupName = "two";

            Group obj2 = new Group();
            obj.GroupName = "three";

            Group obj3 = new Group();
            obj.GroupName = "four";

            Group obj4 = new Group();
            obj.GroupName = "five";

            sortingGroup.Add(obj);
            sortingGroup.Add(obj1);
            sortingGroup.Add(obj2);
            sortingGroup.Add(obj3);
            sortingGroup.Add(obj4);

            GroupItems = sortingGroup; */

            var getREST = ServiceBusRelay.GetAsync<GrantModel>(constantfile.GetGrantMajorGrup + "jarugulav").ContinueWith((taskresponse) =>

                      {
                          var stringres = taskresponse;
                          stringres.Wait();

                          GrantModel userGroupModel = stringres.Result;

                        //   GrantModel userGroupModel = JsonConvert.DeserializeObject<GrantModel>(taskresponse.);

                        ObservableCollection<Group> sortingGroup = new ObservableCollection<Group>();
                        for (int i = 0; i < userGroupModel.Groups.Count; i++)
                          {
                              if (userGroupModel.Groups[i].GroupType.Level_Id == 2)
                              {
                                  sortingGroup.Add(userGroupModel.Groups[i]);
                              }
                          }

                         // pickerRef.ItemsSource = sortingGroup;
                          Device.BeginInvokeOnMainThread(() =>
                          {
                              GroupItems = sortingGroup;
                          });

                    }
                                                                                                                          
                    );

           

         //   getListViewData();

            /* JSSEInfo obj = new JSSEInfo();
			 obj.jsseId = 510;
			 obj.jsseStatus = "Draft";
			 obj.jsseDate = "09/20/2017";


			 JSSEInfo obj1 = new JSSEInfo();
			 obj1.jsseId = 511;
			 obj1.jsseStatus = "Submit";
			 obj1.jsseDate = "09/20/2017";


			 JSSEInfo obj2 = new JSSEInfo();
			 obj2.jsseId = 512;
			 obj2.jsseStatus = "Submit";
			 obj2.jsseDate = "09/20/2017";


			 JSSEInfo obj3 = new JSSEInfo();
			 obj3.jsseId = 513;
			 obj3.jsseStatus = "Draft";
			 obj3.jsseDate = "09/20/2017";


			 JSSEInfo obj4 = new JSSEInfo();
			 obj4.jsseId = 514;
			 obj4.jsseStatus = "Submit";
			 obj4.jsseDate = "09/20/2017";


			 JSSEInfo obj5 = new JSSEInfo();
			 obj5.jsseId = 515;
			 obj5.jsseStatus = "Draft";
			 obj5.jsseDate = "09/20/2017";


			 ListeviewItemSource.Add(obj);
			 ListeviewItemSource.Add(obj1);
			 ListeviewItemSource.Add(obj2);
			 ListeviewItemSource.Add(obj3);
			 ListeviewItemSource.Add(obj4);
			 ListeviewItemSource.Add(obj5);*/



        }

        public void getListViewData()
        {

            //var assembly = typeof(DynamicScreen).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream("SampleDB.getGroupData.json");
            //using (var reader = new System.IO.StreamReader(stream))
            //{

            //	var json = reader.ReadToEnd();
            //	List<GetListViewDataModel> userGroupModel = JsonConvert.DeserializeObject<List<GetListViewDataModel>>(json);
            //	List<User> groupList = new List<User>();
            //	for (int i = 0; i < userGroupModel.Count; i++)
            //	{
            //		ListeviewItemSource.Add(userGroupModel[i]);
            //	}

            //}

        }

        Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                if (selectedGroup != value)
                {
                    selectedGroup = value;
                    SelectedGroupId = selectedGroup.Group_ID;
                    OnPropertyChanged("selectedGroup");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
