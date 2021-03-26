using CatRenta.UpdateCatWPF.Models;
using DataContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatRenta.UpdateCatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EFDataContext _context;
        private ObservableCollection<CatModel> _cats;
        public MainWindow()
        {
            InitializeComponent();
            _cats = new ObservableCollection<CatModel>();
            _context = new EFDataContext();
            DbSeeder.SeedAll(_context);
        }

        private void FillData() 
        {
            var list = _context.cats.Select(x => new CatModel { 
                Id = x.Id,
                Name = x.Name,
                Birthday = x.Birthday,
                ImgUrl = x.UrlImage
            }).ToList();

            this._cats = new ObservableCollection<CatModel>(list);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
            this.dgCats.ItemsSource = _cats;
        }

        private void dgCats_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeDataWindow dlg = new ChangeDataWindow(_context,this.dgCats.SelectedItems[0] as CatModel);
            dlg.ShowDialog();
        }
    }
}
