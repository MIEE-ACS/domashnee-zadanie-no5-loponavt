using System;
using System.Collections.Generic;
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

namespace Homework5
{
    class Room
    {
        private double length;
        private double width;
        private double height;
        private short windows;
        private double square;
        private double volume;

        public double Lenght
        {
            set
            {
                if (value > 0)
                    length = value;
            }
            get
            {
                return length;
            }
        }

        public double Width
        {
            set
            {
                if (value > 0)
                    width = value;
            }
            get
            {
                return width;
            }
        }

        public double Height
        {
            set
            {
                if (value > 0)
                    height = value;
            }
            get
            {
                return height;
            }
        }

        public short Windows
        {
            set
            {
                if (value > 0)
                    windows = value;
            }
            get
            {
                return windows;
            }
        }

        public bool Availability { set; get; }

        public double Square
        {
            set
            {
                square = length * width;
            }
            get
            {
                return square;
            }
        }

        public double Volume
        {
            set
            {
                volume = length * width * height;
            }

            get
            {
                return volume;
            }
        }

        public override string ToString()
        {
            string availability_status;
            switch (Availability)
            {
                case true:
                    availability_status = "Доступна";
                    break;
                case false:
                    availability_status = "Недоступна";
                    break;
            }

            return $"Длина: {length}, Ширина: {width}, Высота: {height}, Кол-во окон: {windows}, Площадь: {square}, Объем: {volume}, {availability_status}";
        }
    }
    public partial class MainWindow : Window
    {
        static List<Room> rooms = new List<Room>
        {
            new Room {Lenght = 30, Width = 40, Height = 50, Windows = 3, Square = 1, Volume = 1, Availability = true},
            new Room {Lenght = 32, Width = 5, Height = 44, Windows = 2, Square = 1, Volume = 1, Availability = true}
        };

        public void initialization()
        {
            foreach (var room in rooms)
            {
                lbRooms.Items.Add(room);
            }
        }

        public void refreshRoomsList()
        {
            lbRooms.Items.Clear();
            foreach (var room in rooms)
            {
                lbRooms.Items.Add(room);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            refreshRoomsList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = new Room
                {
                    Lenght = double.Parse(tbLength.Text),
                    Width = double.Parse(tbWidth.Text),
                    Height = double.Parse(tbHeight.Text),
                    Windows = short.Parse(tbWindows.Text),
                    Square = 1,
                    Volume = 1,
                    Availability = true
                };
                rooms.Add(room);
                refreshRoomsList();
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Room[] rooms_deleted = new Room[lbRooms.SelectedItems.Count];
            lbRooms.SelectedItems.CopyTo(rooms_deleted, 0);
            foreach (var room in rooms_deleted)
            {
                lbRooms.Items.Remove(room);
                rooms.Remove(room);
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Room[] rooms_selected = new Room[lbRooms.SelectedItems.Count];
            lbRooms.SelectedItems.CopyTo(rooms_selected, 0);
            foreach (var room in rooms_selected)
            {
                if (room.Availability == true) room.Availability = false;
                else room.Availability = true;
            }
            refreshRoomsList();
        }
    }
}
