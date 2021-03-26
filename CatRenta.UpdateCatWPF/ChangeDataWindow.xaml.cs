using CatRenta.UpdateCatWPF.Models;
using DataContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CatRenta.UpdateCatWPF
{
    /// <summary>
    /// Interaction logic for ChangeDataWindow.xaml
    /// </summary>
    public partial class ChangeDataWindow : Window
    {
        public EFDataContext _context { get; set; }
        public CatModel _cat { get; set; }
        public ChangeDataWindow(EFDataContext context, CatModel cat)
        {
            InitializeComponent();
            this._cat = cat;
            this._context = context;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtName.Text = _cat.Name;
            this.txtImgUrl.Text = _cat.ImgUrl;
            this.DatePick.SelectedDate = _cat.Birthday;
            this.brdName.BorderBrush = Brushes.LimeGreen;
            this.brdImgUrl.BorderBrush = Brushes.LimeGreen;
            this.txtName.TextChanged += TextChanged;
            this.txtImgUrl.TextChanged += TextChanged;
            
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            string parName = (sender as TextBox).Name;
            string text = (sender as TextBox).Text;
            if (parName == "txtName")
            {
                if (!string.IsNullOrEmpty(text))
                {
                    this.brdName.BorderBrush = Brushes.LimeGreen;
                }
                else 
                {
                    this.brdName.BorderBrush = Brushes.Red;
                }
            }
            else if(parName == "txtImgUrl")  
            {
                if (!string.IsNullOrEmpty(text) && text.StartsWith("http"))
                {
                    this.brdImgUrl.BorderBrush = Brushes.LimeGreen;
                }
                else
                {
                    this.brdImgUrl.BorderBrush = Brushes.Red;
                }
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtName.Text)) 
            {
                _cat.Name=this.txtName.Text;
            }
            if (!string.IsNullOrEmpty(this.txtImgUrl.Text) && this.txtImgUrl.Text.StartsWith("http")) 
            {
                _cat.ImgUrl=this.txtImgUrl.Text;
            }

            if (this.DatePick.SelectedDate.HasValue) 
            {
                _cat.Birthday=this.DatePick.SelectedDate.Value;
            }

            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var el = this._context.cats.FirstOrDefault(x => x.Id == _cat.Id);
            el.Name = _cat.Name;
            el.UrlImage = _cat.ImgUrl;
            el.Birthday = _cat.Birthday;

            this._context.SaveChanges();
        }
    }
}
