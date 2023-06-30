using Shelter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.VievModels;

namespace WpfApp1.Vievs
{
   
    public partial class UbdateAn : Window
    {
        public UbdateAn(Goods goodsToEdit )
        {
            InitializeComponent();
            DataContext = new GetAllVievModels();
            GetAllVievModels.SelectedGoods = goodsToEdit;
            GetAllVievModels.GName = goodsToEdit.Name;
            GetAllVievModels.KName = goodsToEdit.NameKind;
            GetAllVievModels.GPrice = goodsToEdit.Price;
        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
