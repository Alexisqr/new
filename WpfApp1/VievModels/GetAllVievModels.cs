
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Shelter.Domain.Entities;
using System.Windows.Controls;
using System.ComponentModel;
using WpfApp1.Vievs;
using System.Windows;
using Shelter.Infrastructure;
using System.Windows.Media;

namespace WpfApp1.VievModels
{
    public class GetAllVievModels : VievModelsBase
    {

        private List<Goods> allGoods = DataWorker.GetAllGoods();
        public List<Goods> AllGoods
        {
            get { return allGoods; }
            set
            {
                allGoods = value;
               //
               NotifyPropertyChanged("AllDepartments");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static string GName { get; set; }
        public static int KName { get; set; }
        public static int GPrice { get; set; }

        private RelayCommand addNewGoods;
        public RelayCommand AddNewGoods
        {
            get
            {
                return addNewGoods ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (GName == null || GName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    if (KName == 0)
                    {
                        SetRedBlockControll(wnd, "KNameBlock");
                    }
                    if (GPrice == 0)
                    {
                        SetRedBlockControll(wnd, "GPriceBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateGoods(GName, KName, GPrice);
                        ShowMessageToUser(resultStr);
                        UpdateAllView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }

          
                       
                    
                }
                );
            }
        }
     
        public TabItem SelectedTabItem { get; set; }
        public static Goods SelectedGoods { get; set; }
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нічого не обрано";
                  
                    if (SelectedTabItem.Name == "GoodsTab" && SelectedGoods != null)
                    {
                        resultStr = DataWorker.DeleteGoods(SelectedGoods);
                        UpdateAllView();
                    }
                   
                
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }
        private RelayCommand editGoods;
        public RelayCommand EditGoods
        {
            get
            {
                return editGoods ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Нічого не обрано";
                   
                    if (SelectedGoods != null)
                    {
                        
                            resultStr = DataWorker.EditGoods(SelectedGoods, GName, KName, GPrice);
                            UpdateAllView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        
                      
                    }
                    else ShowMessageToUser(resultStr);
                }
                );
            }
        }
        private void SetNullValuesToProperties()
        {
           
            GName = null;
            KName = 0;
            GPrice = 0;
       
         
        }
        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }


        private RelayCommand openAddNewGoodsWnd;
        public RelayCommand OpenAddNewGoodsWnd
        {
            get
            {
                return openAddNewGoodsWnd ?? new RelayCommand(obj =>
                {
                    OpenAddGoodsWindowMethod();
                }
                );
            }
        }
        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    string resultStr = "Нічого не обрано";
               
                    if (SelectedTabItem.Name == "GoodsTab" && SelectedGoods != null)
                    {
                        OpenEditGoodsWindowMethod(SelectedGoods);
                    }
                 
                 
                }
                    );
            }
        }
        private void UpdateAllView()
        {
            UpdateAllGoodsView();
        }
            private void UpdateAllGoodsView()
        {
            AllGoods = DataWorker.GetAllGoods();
            GetAllAn.AllGoodsView.ItemsSource = null;
            GetAllAn.AllGoodsView.Items.Clear();
            GetAllAn.AllGoodsView.ItemsSource = AllGoods;
            GetAllAn.AllGoodsView.Items.Refresh();
        }
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndopen(messageView);
        }
        private void OpenEditGoodsWindowMethod(Goods goods)
        {
            UbdateAn newGoodsWindow = new UbdateAn(goods);
            SetCenterPositionAndopen(newGoodsWindow);
        }
        private void OpenAddGoodsWindowMethod()
        {
            CreateAn newGoodsWindow = new CreateAn();
            SetCenterPositionAndopen(newGoodsWindow);
        }
        private void SetCenterPositionAndopen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

       
    }
}